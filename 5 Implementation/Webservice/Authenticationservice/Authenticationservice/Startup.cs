using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Authenticationservice.Startup))]

namespace Authenticationservice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}
