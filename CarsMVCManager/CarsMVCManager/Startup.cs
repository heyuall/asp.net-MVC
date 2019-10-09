using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarsMVCManager.Startup))]
namespace CarsMVCManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
