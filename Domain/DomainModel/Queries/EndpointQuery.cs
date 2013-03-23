using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Swampy.Domain.Entities.Endpoint;
using Environment = Swampy.Business.DomainModel.Entities.Environment;

namespace Swampy.Domain.Queries
{
    public class EndpointQuery
    {
        public string EndpointName { get; set; }
        public string EnvironmentName { get; set; }

        public IQueryable<IEndpoint> Query(ISession session)
        {
            var result =
                from e in
                    session.Query<Environment>()
                           .Where(en => en.Name == EnvironmentName)
                           .SelectMany(en => en.Endpoints, (ep, r) => r)
                           .Where(endpoint => endpoint.Key == EndpointName)
                select e;

            return result;

        }
    }
}
