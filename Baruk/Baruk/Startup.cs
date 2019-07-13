using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Baruk.Startup))]
namespace Baruk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
