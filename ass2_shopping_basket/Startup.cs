using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ass2_shopping_basket.Startup))]
namespace ass2_shopping_basket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
