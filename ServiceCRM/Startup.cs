using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceCRM.Startup))]
namespace ServiceCRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
