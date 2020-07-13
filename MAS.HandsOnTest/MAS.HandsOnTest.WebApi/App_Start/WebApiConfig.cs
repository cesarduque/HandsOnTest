using MAS.HandsOnTest.Core.Factory;
using MAS.HandsOnTest.Core.Repositories;
using MAS.HandsOnTest.Core.Service;
using MAS.HandsOnTest.Infrastructure.Repositories;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;

namespace MAS.HandsOnTest.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            //Unity Configuration
            var container = new UnityContainer();
            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<IEmployeeRepository, EmployeeRepository>(hierarchicalLifetimeManager);
            }

            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<IEmployeeService, EmployeeService>(hierarchicalLifetimeManager);
            }

            using (var hierarchicalLifetimeManager = new HierarchicalLifetimeManager())
            {
                container.RegisterType<ISalaryFactory, SalaryFactory>(hierarchicalLifetimeManager);
            }

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
               = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SerializerSettings.Formatting
                = Newtonsoft.Json.Formatting.Indented;
        }
    }
}
