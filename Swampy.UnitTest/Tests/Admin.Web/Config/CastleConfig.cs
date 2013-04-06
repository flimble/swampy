using System;
using System.Linq;
using Castle.Core;
using Castle.MicroKernel;
using Castle.Windsor;
using NUnit.Framework;
using Swampy.Admin.Web.App_Start;
using Swampy.Business.Infrastructure.Logging.Swampy.Service.Infrastructure;

namespace Swampy.UnitTest.Tests.Admin.Web.Config
{
    [TestFixture]
    public class CastleConfigTest
    {
        private readonly IWindsorContainer _container;

        public CastleConfigTest()
        {
            _container = CastleWindsorConfig.Configure();
        }

        [Test]
        public void validate_singleton_object_scope()
        {            
            AssertRegisteredTransient<ILogFactory>("bla");
                     
        }

      
        private LifestyleType GetLifeStyle(IHandler handler)
        {
            return handler.ComponentModel.LifestyleType;
        }

        public void Is<TService>(string reason, Func<IHandler, bool> predicate)
        {
            var handlers = _container.Kernel.GetHandlers(typeof (TService));
            if(!handlers.Any(predicate))
                Assert.Fail("Component {0} is not registered correctly: {1}", typeof(TService).Name, reason);
        }

        public void AssertRegisteredTransient<TService>(string reason)
        {
            Is<TService>(reason, x=>GetLifeStyle(x) == LifestyleType.Transient);
        }

        public void AssertRegisteredSingleton<TService>(string reason)
        {
            Is<TService>(reason, x =>
                {
                    var lifestyle = GetLifeStyle(x);
                    return (lifestyle == LifestyleType.Singleton || lifestyle == LifestyleType.Undefined);
                });
        }


        public void AssertRegisteredPerRequest<TService>(string reason)
        {
            Is<TService>(reason, x => GetLifeStyle(x) == LifestyleType.PerWebRequest);
        }
        
    }
}
