using System;
using System.Collections.Generic;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;
using Rhino.Mocks;
using SAIG.PS.Swampy.Shared.Infrastructure;
using SAIG.PS.Swampy.Shared.Infrastructure.SAIG.PS.Swampy.Service.Infrastructure;
using log4net;
using log4net.Config;

namespace SAIG.PS.Swampy.UnitTest.Infrastructure
{
    [TestFixture]
    public class LoggingInterceptor_Test
    {
        private IWindsorContainer RegisterContainer(FakeLogFactory factory, Type actionType)
        {
            var container = new WindsorContainer();
            container.Register(
                Component.For<LoggingInterceptor>(),
                Component.For<ILogFactory>().Instance(factory),
                Component.For<IAnyObject>().ImplementedBy(actionType)
                .Interceptors(new InterceptorReference(typeof(LoggingInterceptor))).First
            );
            BasicConfigurator.Configure(); // configure log4net

            return container;
        }

        [Test]
        public void interceptor_logs_registered_class_entry_and_result()
        {
            //arrange
            var factory = new FakeLogFactory(true);
            var container = RegisterContainer(factory, typeof(SuccessObject));

            var action = container.Resolve<IAnyObject>();
            
            //act
            action.DoSomething("a", "b");

            //assert
            Assert.AreEqual(2, factory.MessagesLogged.Count);
            Assert.AreEqual(2, factory.MessagesLogged.Count);
        }

        [Test]
        public void interceptor_noes_not_log_on_success_with_debug_off()
        {
            //arrange
            var factory = new FakeLogFactory(false);
            var container = RegisterContainer(factory, typeof(SuccessObject));

            var action = container.Resolve<IAnyObject>();

            //act
            action.DoSomething("a", "b");

            //assert
            Assert.AreEqual(0, factory.MessagesLogged.Count);
        }



        [Test]
        public void interceptor_logs_execption_with_debug_off()
        {
            //arrange
            var factory = new FakeLogFactory(false);
            var container = RegisterContainer(factory, typeof(FailureObject));

            var action = container.Resolve<IAnyObject>();

            //act
            try
            {
                action.DoSomething("a", "b");
            }
            catch
            {
 
            }
           

            //assert
            Assert.AreEqual(1, factory.MessagesLogged.Count);
        }


        public class SuccessObject : IAnyObject
        {
            public string DoSomething(string valueA, string valueB)
            {
                return valueA + valueB;
            }
        }

        public interface IAnyObject
        {
            string DoSomething(string valueA, string valueB);
        }
        
        public class FailureObject : IAnyObject
        {
            public string DoSomething(string valueA, string valueB)
            {
                throw new ArgumentException("Failed on purpose");
            }
        }

        public class FakeLogFactory : ILogFactory
        {
            private readonly bool _enableDebug;

            public FakeLogFactory(bool enableDebug)
            {
                _enableDebug = enableDebug;
            }

            #region Implementation of ILogFactory

            public List<string> MessagesLogged = new List<string>();

            public ILog GetLogger(Type type)
            {
                var stub = MockRepository.GenerateMock<ILog>();
                stub.Stub(x => x.IsDebugEnabled).Return(_enableDebug);
                stub.Stub(x => x.Debug(null)).IgnoreArguments()
                    .WhenCalled(
                    x=>
                        {
                            MessagesLogged.Add(x.Arguments[0].ToString());
                        }
                    );
                stub.Stub(x => x.Error(null)).IgnoreArguments()
                    .WhenCalled(
                    x =>
                    {
                        MessagesLogged.Add(x.Arguments[0].ToString());
                    }
                    );

                return stub;
            }

            

            #endregion
        }
    }
}
