﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.Facebook;

namespace DarehService.API.Provides
{
  public class FacebookAuthProvider : FacebookAuthenticationProvider
  {
    public override Task Authenticated(FacebookAuthenticatedContext context)
    {
      context.Identity.AddClaim(new Claim("ExternalAccessToken", context.AccessToken));
      return Task.FromResult<object>(null);
    }
  }
}