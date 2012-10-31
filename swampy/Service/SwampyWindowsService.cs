using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Swampy.Domain.Contract;
using Swampy.Domain.DomainServices;
using Swampy.Domain.Infrastructure;
using Swampy.Shared.Infrastructure;
using Swampy.WcfService;
using log4net;
using log4net.Repository.Hierarchy;

namespace Swampy.Service
{
    public class SwampyWindowsService : ServiceBase
    {
        private static ILog Logger = LogManager.GetLogger(typeof (SwampyWindowsService));

        public SwampyWindowsService()
        {
            this.ServiceName = this.ToString();
        }

        public ServiceHost ServiceHost = null;

        protected override void OnStart(string[] args)
        {
            

            if(ServiceHost != null)
            {
                ServiceHost.Close();
            }

            var domainService = new ProxyGenerator().CreateInterfaceProxyWithTargetInterface<ISwampyEndpointService>(
                new SwampyEndpointService(),
                new LoggingInterceptor(new LogFactory()));

            ServiceHost = new ServiceHost(new EndpointService(domainService));
            ServiceHost.Open();

        }

        static void Main(string[] args)
        {
            var service = new SwampyWindowsService();

            if (Environment.UserInteractive)
            {
                service.OnStart(args);
                Logger.DebugFormat("Started windows service");
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
