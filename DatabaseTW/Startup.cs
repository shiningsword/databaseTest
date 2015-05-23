using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DatabaseTW.Startup))]
namespace DatabaseTW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
