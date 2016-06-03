using System;
using System.Reflection;
using System.Web.Http;
using DarehService.API;
using DarehService.API.Config;
using DarehService.API.Provides;
using Microsoft.Owin;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace DarehService.API
{
  public class Startup
  {
    public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
    //public static GoogleOAuth2AuthenticationOptions googleAuthOptions { get; private set; }
    public static FacebookAuthenticationOptions facebookAuthOptions { get; private set; }

    public void Configuration(IAppBuilder app)
    {
      var config = new HttpConfiguration();

      ConfigurationOAuth(app);
      WebApiConfig.Register(config);
      app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
      app.UseNinjectMiddleware(() => NinjectConfig.CreateKernel.Value).UseNinjectWebApi(config);
  

    }

    public void ConfigurationOAuth(IAppBuilder app)
    {
      app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
      OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

      var OAuthServerOptions = new OAuthAuthorizationServerOptions()
      {
        AllowInsecureHttp = true,
        TokenEndpointPath = new PathString("/token"),
        AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
        Provider = new DarehAuthorizationServerProvider(),
        RefreshTokenProvider = new DarehRefreshTokenProvider()
      };

      // Token Generation
      app.UseOAuthAuthorizationServer(OAuthServerOptions);
      app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

      //Configure Facebook External Login
      facebookAuthOptions = new FacebookAuthenticationOptions()
      {
        AppId = "1788153101418482",
        AppSecret = "0269b29ddc7ded02720370640d2fea78",
        Provider = new FacebookAuthProvider()
      };
      app.UseFacebookAuthentication(facebookAuthOptions);

    }

  }
}