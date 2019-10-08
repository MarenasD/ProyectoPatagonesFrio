using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Patagones.Startup))]
namespace Patagones
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
