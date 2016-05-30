﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DarehService.API.Helpers;
using DarehService.API.Models;
using DarehService.API.Models.Enums;
using DarehService.API.Repositiries;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace DarehService.API.Provides
{
  public class DarehAuthorizationServerProvider : OAuthAuthorizationServerProvider
  {
    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
      var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

      if (allowedOrigin == null) allowedOrigin = "*";

      context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {allowedOrigin});

      using (var _repo = new AuthRepository())
      {
        var user = await _repo.FindUser(context.UserName, context.Password);

        if (user == null)
        {
          context.SetError("invalid_grant", "The user name or password is incorrect.");
          return;
        }
      }

      var identity = new ClaimsIdentity(context.Options.AuthenticationType);
      identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
      identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
      identity.AddClaim(new Claim("sub", context.UserName));

      var props = new AuthenticationProperties(new Dictionary<string, string>
      {
        {
          "as:client_id", context.ClientId ?? string.Empty
        },
        {
          "userName", context.UserName
        }
      });

      var ticket = new AuthenticationTicket(identity, props);
      context.Validated(ticket);
    }

    public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
    {
      var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
      var currentClient = context.ClientId;

      if (originalClient != currentClient)
      {
        context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
        return Task.FromResult<object>(null);
      }

      // Change auth ticket for refresh token requests
      var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

      var newClaim = newIdentity.Claims.FirstOrDefault(c => c.Type == "newClaim");
      if (newClaim != null)
      {
        newIdentity.RemoveClaim(newClaim);
      }
      newIdentity.AddClaim(new Claim("newClaim", "newValue"));

      var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
      context.Validated(newTicket);

      return Task.FromResult<object>(null);
    }

    public override Task TokenEndpoint(OAuthTokenEndpointContext context)
    {
      foreach (var property in context.Properties.Dictionary)
      {
        context.AdditionalResponseParameters.Add(property.Key, property.Value);
      }

      return Task.FromResult<object>(null);
    }


    public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
      string clientId = String.Empty;
      string clientSecret = String.Empty;
      Task<Client> client = null;

      if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
      {
        context.TryGetFormCredentials(out clientId, out clientSecret);
      }

      if (context.ClientId == null)
      {
        //Remove the comments from the below line context.SetError, and invalidate context 
        //if you want to force sending clientId/secrects once obtain access tokens. 
        context.Validated();
        //context.SetError("invalid_clientId", "ClientId should be sent.");
        return Task.FromResult<object>(null);
      }

      using (var _repo = new ClientRepositoriy())
      {
        client = _repo.GetById(context.ClientId);
      }

      if (client.Result.ApplicationType == ApplicationTypes.NativeConfidential)
      {
        if (string.IsNullOrWhiteSpace(clientSecret))
        {
          context.SetError("invalid_clientId", "Client secret should be sent.");
          return Task.FromResult<object>(null);
        }
        if (client.Result.Password != MainHelper.GetHash(clientSecret))
        {
          context.SetError("invalid_clientId", "Client secret is invalid.");
          return Task.FromResult<object>(null);
        }
      }

      if (!client.Result.Active)
      {
        context.SetError("invalid_clientId", "Client is inactive.");
        return Task.FromResult<object>(null);
      }

      context.OwinContext.Set("as:clientAllowedOrigin", client.Result.AllowedOrigin);
      context.OwinContext.Set("as:clientRefreshTokenLifeTime", client.Result.RefreshTokenLifeTime.ToString());

      context.Validated();
      return Task.FromResult<object>(null);
    }
  }
}