using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaEncuestas.Startup))]
namespace SistemaEncuestas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
