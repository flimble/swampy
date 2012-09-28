using System.Collections.Generic;
using System.Linq;
using SAIG.PS.Swampy.Service.Entities;
using SAIG.PS.Swampy.Service.Entities.Endpoint;

namespace SAIG.PS.Swampy.Service.QueryObjects
{
    public static class Query
    {
        public static IQueryable<EndpointBase> Top5DatabaseConnectionStrings(IQueryable<Environment> existingQuery)
        {
            return existingQuery
                .SelectMany(x => x.Endpoints)
                .Where(x => x.Value == "deh");
        }

        public static IQueryable<EndpointBase> GetEndpointByEnvironmentName(this IQueryable<Environment> existingQuery,
                                                                             string environmentName)
        {
            return existingQuery.First(x => x.Name == environmentName).Endpoints.AsQueryable();
        }

        public static IQueryable<EndpointBase> EndpointsWithMatchingKey(this IQueryable<EndpointBase> existingQuery, IList<string> keys)
        {
            return existingQuery.Where(x => keys.Contains(x.Key));
        }
    
}
}
