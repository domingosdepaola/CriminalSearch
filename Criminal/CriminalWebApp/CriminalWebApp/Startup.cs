using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CriminalWebApp.Startup))]
namespace CriminalWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
