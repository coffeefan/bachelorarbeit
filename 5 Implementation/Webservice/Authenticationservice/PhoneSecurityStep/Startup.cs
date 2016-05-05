using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhoneSecurityStep.Startup))]
namespace PhoneSecurityStep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
