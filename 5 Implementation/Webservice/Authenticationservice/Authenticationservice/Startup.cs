using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Authenticationservice.Startup))]
namespace Authenticationservice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
