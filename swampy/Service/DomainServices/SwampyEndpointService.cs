using System.Linq;
using Raven.Client;
using Swampy.Service.Contract;
using Environment = Swampy.Service.Entities.Environment;

namespace Swampy.Service.DomainServices
{
    public class SwampyEndpointService : IEndpointService
    {
        private IDocumentSession _session;

        #region Implementation of IEndpointService
        public SwampyEndpointService(IDocumentSession session)
        {
            _session = session;
        }


        public KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication)
        {
            var environmentData =
                _session.Query<Environment>().Where(x => x.Name == environment).ToList()
                    .SelectMany(x => x.Endpoints).Where(y => keys.Contains(y.Key));            

            var keypairs = environmentData.Select(e => new KeyPair(e.Key, e.Value));

            return keypairs.ToArray();
        }

        public KeyPair GetSingleEndpoint(string environment, string key, string callingApplication)
        {
            var result = GetEndpoints(environment, new[] {key}, callingApplication).First();

            return result;
        }

        #endregion
    }
}
