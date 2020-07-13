using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MAS.HandsOnTest.WebApi.Startup))]

namespace MAS.HandsOnTest.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();            

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);            

            WebApiConfig.Register(config);            

            app.UseWebApi(config);
        }
    }
}
