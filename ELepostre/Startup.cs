using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ELepostre.Startup))]
namespace ELepostre
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
