using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiCursos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            // Web API configuration and services
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.Objects;
          

           config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API routes
            config.EnableCors();
            
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "Curso1P",
                routeTemplate: "v1/{controller}/{action}/{args}",
                defaults: new { args = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Curso2P",
                routeTemplate: "v1/{controller}/{action}/{args}/{args2}",
                defaults: new
                {
                    args = RouteParameter.Optional,
                    args2 = RouteParameter.Optional

                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
