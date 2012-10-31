using Swampy.Domain.Contract;
using Swampy.Domain.DomainServices;
using log4net;

namespace Swampy.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class EndpointService : IEndpointService
    {
        private static ILog _logger = LogManager.GetLogger("EndpointService");

        protected IEndpointService domainService;

        #region Implementation of IEndpointService
        public EndpointService()
        {
            SwampyEndpointService.Initialize();
        }


        public KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication)
        {
            _logger.Debug("GetEndpoints");

            return domainService.GetEndpoints(environment, keys, callingApplication);
        }

        public KeyPair GetSingleEndpoint(string environment, string key, string callingApplication)
        {
            _logger.Debug("GetSingleEndpoint");

            return domainService.GetSingleEndpoint(environment, key, callingApplication);
        }

        #endregion
    }
}
