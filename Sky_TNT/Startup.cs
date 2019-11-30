using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sky_TNT.Startup))]
namespace Sky_TNT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
