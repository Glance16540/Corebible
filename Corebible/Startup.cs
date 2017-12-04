using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Corebible.Startup))]
namespace Corebible
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
