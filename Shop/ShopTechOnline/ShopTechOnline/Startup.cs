using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopTechOnline.Startup))]
namespace ShopTechOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
