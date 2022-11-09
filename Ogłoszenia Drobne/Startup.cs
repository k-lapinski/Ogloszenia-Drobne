using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ogłoszenia_Drobne.Startup))]
namespace Ogłoszenia_Drobne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
