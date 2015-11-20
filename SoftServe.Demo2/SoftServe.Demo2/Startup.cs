using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoftServe.Demo2.Startup))]
namespace SoftServe.Demo2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
