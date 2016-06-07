using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DarehService.ResourceServer.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(DarehService.ResourceServer.Startup))]
namespace DarehService.ResourceServer
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      var config = new HttpConfiguration();

      ConfigurationOAuth(app);

      WebApiConfig.Register(config);

    }

    private void ConfigurationOAuth(IAppBuilder app)
    {
      app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
      {

      });
    }
  }
}