using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Swampy.Business.Contract;
using Swampy.Business.DomainModel.Entities;
using Swampy.Business.Infrastructure.NHibernate.Session;

namespace Swampy.Business.DomainServices
{
    public class SwampyEndpointService : ISwampyEndpointService
    {
        
        

        public KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication)
        {            
            var env = UnitOfWork.GetCurrentSession.Query<SwampyEnvironment>().SingleOrDefault(x => x.Name.ToLower() == environment.ToLower());
            env.HydrateItems();

            keys = Array.ConvertAll(keys, x=>x.ToLower());

            var keypairs = env.ConfigurationItems.Where(x=> keys.Contains(x.Name.ToLower())).Select(e => new KeyPair(e.Name, e.HydratedValue));

            return keypairs.ToArray();
        }

        public KeyPair GetSingleEndpoint(string environment, string key, string callingApplication)
        {
            key = key.ToLower();

            var singleOrDefault = UnitOfWork.GetCurrentSession.Query<SwampyEnvironment>().SingleOrDefault(x => x.Name == environment);
            

            if (singleOrDefault != null)
            {
                singleOrDefault.HydrateItems();

                var endpoint = singleOrDefault
                                      .ConfigurationItems.SingleOrDefault(x => x.Name.ToLower() == key);

                if (endpoint == null)
                {
                    throw new ApplicationException(
                        string.Format("Endpoint: '{0}' does not exist in environment: {1}", environment, key)
                        );
                }

                return new KeyPair(endpoint.Name, endpoint.HydratedValue);
            }
            return null;
        }
    }
}
