using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogV3.Startup))]
namespace BlogV3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
