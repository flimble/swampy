using System.Linq;
using SAIG.PS.Swampy.MongoDataAccess;
using SAIG.PS.Swampy.Service.Contract;
using SAIG.PS.Swampy.Service.QueryObjects;
using Environment = SAIG.PS.Swampy.Service.Entities.Environment;

namespace SAIG.PS.Swampy.Service.DomainServices
{
    public class SwampyEndpointService : IEndpointService
    {
        private ISession _session;

        #region Implementation of IEndpointService
        public SwampyEndpointService(ISession session)
        {
            _session = session;
        }


        public KeyPair[] GetEndpoints(string environment, string[] keys)
        {
            var environmentData =
                _session.Query(new EnvironmentByNameQuery
                                   {
                                       EnvironmentName = environment,
                                   }).Single().Endpoints.Where(x => keys.Contains(x.Key));
            

            var keypairs = environmentData.Select(e => new KeyPair(e.Key, e.Value));

            return keypairs.ToArray();
        }

        public KeyPair GetSingleEndpoint(string environment, string key)
        {
            var result = GetEndpoints(environment, new[] {key}).First();

            return result;
        }

        #endregion
    }
}
