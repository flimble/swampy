using System.Linq;
using Swampy.Domain.Contract;
using Swampy.Domain.Entities;

namespace Swampy.Domain.DomainServices
{
    public class SwampyEndpointService : IEndpointService
    {
      
        public static void Initialize()
        {
            DataDocumentStore.Initialize();
        }
        

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
                        .Endpoints.Single(x => x.Key == key);


                return new KeyPair(e.Key, e.Value);
            }
        }


    }
}
