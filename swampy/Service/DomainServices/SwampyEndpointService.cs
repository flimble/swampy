using System.Linq;
using Swampy.MongoDataAccess;
using Swampy.Service.Contract;
using Swampy.Service.QueryObjects;
using Environment = Swampy.Service.Entities.Environment;

namespace Swampy.Service.DomainServices
{
    public class SwampyEndpointService : IEndpointService
    {
        private ISession _session;

        #region Implementation of IEndpointService
        public SwampyEndpointService(ISession session)
        {
            _session = session;
        }


        public KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication)
        {
            var environmentData =
                _session.Query(new EnvironmentByNameQuery
                                   {
                                       EnvironmentName = environment,
                                   }).Single().Endpoints.Where(x => keys.Contains(x.Key));
            

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
