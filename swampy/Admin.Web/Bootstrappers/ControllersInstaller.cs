﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Swampy.Admin.Web.Controllers;

namespace Swampy.Admin.Web.Bootstrappers
{
    /*public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                                   .BasedOn<IController>()
                                   .If(Component.IsInSameNamespaceAs<HomeController>())
                                   .If(t => t.Name.EndsWith("Controller"))
                                   .Configure(c => c.LifestyleTransient()));
        }
    }*/
}