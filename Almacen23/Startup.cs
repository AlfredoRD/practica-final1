using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Almacen23.Startup))]
namespace Almacen23
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
