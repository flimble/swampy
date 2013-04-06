using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Swampy.Business.Infrastructure.Logging;
using Swampy.Business.Infrastructure.Logging.Swampy.Service.Infrastructure;

namespace Swampy.Admin.Web.App_Start
{
    public class CastleWindsorConfig
    {
        public static IWindsorContainer Configure()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<LoggingInterceptor>());
            container.Register(Component.For<ILogFactory>().ImplementedBy<LogFactory>().LifeStyle.Transient);
            return container;
        }
    }
}