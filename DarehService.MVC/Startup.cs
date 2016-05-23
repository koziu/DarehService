using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DarehService.MVC.Startup))]
namespace DarehService.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
