using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebForum
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "BoardApi",
                routeTemplate: "api/v1/Board/{id}",
                defaults: new { controller = "apiBoard", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "PostApi",
                routeTemplate: "api/v1/Post/{id}",
                defaults: new { controller = "apiPost", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "LoginApi",
                routeTemplate: "api/v1/Login/",
                defaults: new { controller="apiLogin" }
            );

            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate: "api/v1/Users/{id}",
                defaults: new { controller = "apiUser", id = RouteParameter.Optional }
            );
        }
    }
}
