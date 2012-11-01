using System;
using System.Linq;
using Swampy.Domain.Contract;
using Environment = Swampy.Domain.Entities.Environment;

namespace Swampy.Domain.DomainServices
{
    public class SwampyEndpointService : ISwampyEndpointService
    {
             

        public KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication)
        {
            using (var session = DataDocumentStore.Instance.OpenSession())
            {

                var env =
                    session.Query<Environment>().Single(x => x.Name == environment);

                var keypairs = env.Endpoints.Select(e => new KeyPair(e.Key, e.Value));

                return keypairs.ToArray();
            }
        }

        public KeyPair GetSingleEndpoint(string environment, string key, string callingApplication)
        {
            using (var session = DataDocumentStore.Instance.OpenSession())
            {

                var e =
                    session.Query<Environment>().Single(x => x.Name == environment)
                        .Endpoints.SingleOrDefault(x => x.Key == key);

                if(e == null)
                {
                    throw new ApplicationException(
                        string.Format("Endpoint: '{0}' does not exist in environment: {1}", environment, key)
                        );
                }

                return new KeyPair(e.Key, e.Value);
            }
        }


    }
}
