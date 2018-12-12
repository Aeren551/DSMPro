using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DSM2.Startup))]
namespace DSM2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
