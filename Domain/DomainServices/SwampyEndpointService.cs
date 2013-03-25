using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Swampy.Business.Contract;
using Environment = Swampy.Business.DomainModel.Entities.Environment;

namespace Swampy.Business.DomainServices
{
    public class SwampyEndpointService : ISwampyEndpointService
    {
        private ISession Session;

        public void SetSession(ISession session)
        {
            this.Session = session;
        }

        public KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication)
        {
            var env = Session.Query<Environment>().SingleOrDefault(x => x.Name == environment);
            var keypairs = env.Endpoints.Select(e => new KeyPair(e.Key, e.Value));

            return keypairs.ToArray();
        }

        public KeyPair GetSingleEndpoint(string environment, string key, string callingApplication)
        {
            var singleOrDefault = Session.Query<Environment>().SingleOrDefault(x => x.Name == environment);
            if (singleOrDefault != null)
            {
                var endpoint = singleOrDefault
                                      .Endpoints.SingleOrDefault(x => x.Key == key);

                if (endpoint == null)
                {
                    throw new ApplicationException(
                        string.Format("Endpoint: '{0}' does not exist in environment: {1}", environment, key)
                        );
                }

                return new KeyPair(endpoint.Key, endpoint.Value);
            }
            return null;
        }
    }
}
