using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Newsletter.Web.Startup))]
namespace Newsletter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
