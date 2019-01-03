using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DSMF.Startup))]
namespace DSMF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
