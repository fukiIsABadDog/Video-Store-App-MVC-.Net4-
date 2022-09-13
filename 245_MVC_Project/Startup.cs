using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_245_MVC_Project.Startup))]
namespace _245_MVC_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
