using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Modules;
using WebApiUI.App_Start;

namespace WebApiUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
            // Web API configuration and services
            //var cors = new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*");
            //cors.SupportsCredentials = true;
            //config.EnableCors(cors);

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
