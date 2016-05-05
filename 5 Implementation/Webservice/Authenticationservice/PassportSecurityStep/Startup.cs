using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PassportSecurityStep.Startup))]
namespace PassportSecurityStep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
