using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fatec.Mvc.Startup))]
namespace Fatec.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
