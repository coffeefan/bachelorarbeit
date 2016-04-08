using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMailSecurityStep.Startup))]
namespace EMailSecurityStep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
