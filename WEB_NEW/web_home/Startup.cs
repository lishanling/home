using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(web_home.Startup))]
namespace web_home
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
