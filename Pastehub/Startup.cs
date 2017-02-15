using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pastehub.Startup))]
namespace Pastehub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
