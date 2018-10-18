using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tpFinal.Startup))]
namespace tpFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
