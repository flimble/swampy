using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Swampy.Business.Contract;
using Swampy.Business.DomainModel.Entities;

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
            var env = Session.Query<SwampyEnvironment>().SingleOrDefault(x => x.Name == environment);
            var keypairs = env.ConfigurationItems.Select(e => new KeyPair(e.Name, e.Name));

            return keypairs.ToArray();
        }

        public KeyPair GetSingleEndpoint(string environment, string key, string callingApplication)
        {
            var singleOrDefault = Session.Query<SwampyEnvironment>().SingleOrDefault(x => x.Name == environment);
            if (singleOrDefault != null)
            {
                var endpoint = singleOrDefault
                                      .ConfigurationItems.SingleOrDefault(x => x.Name == key);

                if (endpoint == null)
                {
                    throw new ApplicationException(
                        string.Format("Endpoint: '{0}' does not exist in environment: {1}", environment, key)
                        );
                }

                return new KeyPair(endpoint.Name, endpoint.Name);
            }
            return null;
        }
    }
}
