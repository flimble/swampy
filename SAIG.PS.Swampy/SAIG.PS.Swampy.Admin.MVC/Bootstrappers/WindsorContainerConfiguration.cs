using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using FluentValidation.Mvc;
using SAIG.PS.Swampy.MongoDataAccess;
using Component = Castle.MicroKernel.Registration.Component;

namespace SAIG.PS.Swampy.Admin.MVC.Bootstrappers
{
    public static class WindsorContainerConfiguration
    {
        public static IWindsorContainer Configure()
        {
            var container = new WindsorContainer()
                .Install(FromAssembly.This());


            container.Register(
                Component.For<ISession>()
                    .ImplementedBy<Session>()
                    .DependsOn(Dependency.OnAppSettingsValue(dependencyName: "connectionString", settingName: "MongoServer"))
                    .DependsOn(Dependency.OnAppSettingsValue(dependencyName: "databaseName", settingName: "MongoDatabase"))
                );


            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            return container;

        }
    }
}