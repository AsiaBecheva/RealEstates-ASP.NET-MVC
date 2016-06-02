using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealEstates.Web.Startup))]
namespace RealEstates.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
