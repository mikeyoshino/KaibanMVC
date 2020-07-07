using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kaiban.Startup))]
namespace Kaiban
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
