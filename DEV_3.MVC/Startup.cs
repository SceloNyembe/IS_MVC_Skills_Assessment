using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DEV_3.MVC.Startup))]
namespace DEV_3.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
