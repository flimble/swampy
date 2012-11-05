using System;
using System.ServiceModel;
using System.ServiceProcess;
using Castle.DynamicProxy;
using Swampy.Domain;
using Swampy.Domain.Contract;
using Swampy.Domain.DomainServices;
using Swampy.Domain.Infrastructure;
using log4net;

namespace Swampy.Service
{
    public class SwampyWindowsService : ServiceBase
    {
        protected static ILog Logger = LogManager.GetLogger(typeof (SwampyWindowsService));

        public ServiceHost ServiceHost = null;

        protected override void OnStart(string[] args)
        {
            

            if(ServiceHost != null)
            {
                ServiceHost.Close();
            }


            DataDocumentStore.Initialize();

            //create domainservice with aop logging enabled using dynamic-proxy
            var domainService = LoggingDecorator.Decorate<ISwampyEndpointService>(
                new SwampyEndpointService()
                );

            ServiceHost = new ServiceHost(new EndpointService(domainService));
            ServiceHost.Open();

        }

        static void Main(string[] args)
        {
            var service = new SwampyWindowsService();

            if (Environment.UserInteractive)
            {
                service.OnStart(args);
                Logger.DebugFormat("Starting service in interactive mode");
                Console.Read();
                service.OnStop();
            }
            else
            {
                ServiceBase.Run(service);
            }

        }


        protected override void OnStop()
        {
            if (ServiceHost != null)
            {
                ServiceHost.Close();
                ServiceHost = null;
            }
        }


        
    }
}
