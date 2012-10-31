using System.ServiceModel;
using Swampy.Domain.Contract;
using Swampy.Domain.DomainServices;
using log4net;

namespace Swampy.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EndpointService : IEndpointService
    {
        private static ILog _logger = LogManager.GetLogger("EndpointService");

        protected ISwampyEndpointService _domainService;

        public EndpointService(ISwampyEndpointService domainService)  
        {
            _domainService = domainService;
        }

        public KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication)
        {
            return _domainService.GetEndpoints(environment, keys, callingApplication);
        }

        public KeyPair GetSingleEndpoint(string environment, string key, string callingApplication)
        {
            return _domainService.GetSingleEndpoint(environment, key, callingApplication);
        }
    }
}
