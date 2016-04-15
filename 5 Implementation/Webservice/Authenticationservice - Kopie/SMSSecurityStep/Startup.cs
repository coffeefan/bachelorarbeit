using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SMSSecurityStep.Startup))]
namespace SMSSecurityStep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
