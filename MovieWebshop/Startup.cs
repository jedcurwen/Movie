using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieWebshop.Startup))]
namespace MovieWebshop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
