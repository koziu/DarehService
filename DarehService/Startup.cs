using System.Reflection;
using System.Web.Http;
using DarehService.API;
using DarehService.API.Config;
using Microsoft.Owin;
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
      
      WebApiConfig.Register(config);
      //app.UseWebApi(config);
      app.UseNinjectMiddleware(() => NinjectConfig.CreateKernel.Value).UseNinjectWebApi(config);
    }

    private static StandardKernel CreateKernel()
    {
      var kernel = new StandardKernel();
      kernel.Load(Assembly.GetExecutingAssembly());
      return kernel;
    }
  }
}