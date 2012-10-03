using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SAIG.PS.Swampy.Admin.MVC.Bootstrappers;
using SAIG.PS.Swampy.MongoDataAccess;
using SAIG.PS.Swampy.Service;

namespace SAIG.PS.Swampy.Admin.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            
            BootstrapContainer();
            
            MongoConfiguration.Configure();

        }

        private static IWindsorContainer container;

        private static void BootstrapContainer()
        {
            container = new WindsorContainer()
                .Install(FromAssembly.This());


            /*container.Resolve<ISession>(new Session(ConfigurationManager.AppSettings["MongoServer"],
                                                    ConfigurationManager.AppSettings["MongoDatabase"]));*/

            //string connectionString, string databaseName
            container.Register(
                Component.For<ISession>()
                    .ImplementedBy<Session>()
                    .DependsOn(Dependency.OnAppSettingsValue(dependencyName: "connectionString", settingName: "MongoServer"))
                    .DependsOn(Dependency.OnAppSettingsValue(dependencyName: "databaseName", settingName: "MongoDatabase"))
                );


            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

        }

        
    }
}