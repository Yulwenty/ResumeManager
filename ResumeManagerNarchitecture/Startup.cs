using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResumeManagerNarchitecture.Startup))]
namespace ResumeManagerNarchitecture
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
