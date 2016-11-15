using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeCrud.Web.Startup))]
namespace HomeCrud.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
