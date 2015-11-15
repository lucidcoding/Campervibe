using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Campervibe.External.UI.Startup))]
namespace Campervibe.External.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
