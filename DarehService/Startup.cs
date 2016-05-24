using System;
using System.Reflection;
using System.Web.Http;
using DarehService.API;
using DarehService.API.Config;
using DarehService.API.Provides;
using Microsoft.Owin;
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
      
      var OAuthServerOptions = new OAuthAuthorizationServerOptions()
      {
        AllowInsecureHttp = true,
        TokenEndpointPath = new PathString("/token"),
        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        Provider = new DarehAuthorizationServerProvider()
      };

      // Token Generation
      app.UseOAuthAuthorizationServer(OAuthServerOptions);
      app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

    }

    private static StandardKernel CreateKernel()
    {
      var kernel = new StandardKernel();
      kernel.Load(Assembly.GetExecutingAssembly());
      return kernel;
    }
  }
}