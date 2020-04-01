using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

using CatalogApi.MIddleWare;
using CatalogApi.Repository;
using Newtonsoft.Json.Serialization;
using Unity;
using Unity.Lifetime;

namespace CatalogApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.MessageHandlers.Add(new MessageHandler1());
            //config.MessageHandlers.Add(new MessageHandler2());
           // config.MessageHandlers.Add(new APIKeyHandler("Test"));

            var container = new UnityContainer();
            container.RegisterType<ICatalogRepository, CatalogRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.Filters.Add(new NotImplExceptionFilterAttribute());
           // config.Filters.Add(new AuthorizeAttribute());

            config.Filters.Add(new ValidateModelAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
               // constraints: null
               // handler: new MessageHandler2()
            );

            //config.Formatters.Remove(config.Formatters.JsonFormatter);
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            //config.Formatters.Add(new BsonMediaTypeFormatter());
           // config.Formatters.Add(new CatalogCSVFormatter());

            // Convert all dates to UTC
          /*  var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
           // var csv = new CatalogCSVFormatter();
           

            json.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); */

           // var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
           // xml.UseXmlSerializer = true;
        }
    }
}
