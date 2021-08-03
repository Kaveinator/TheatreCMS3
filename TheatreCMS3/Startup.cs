using Microsoft.Owin;
using Owin;
using TheatreCMS3.Areas.Rent.Models;

[assembly: OwinStartupAttribute(typeof(TheatreCMS3.Startup))]
namespace TheatreCMS3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            HistoryManager.Seed();
        }
    }
}
