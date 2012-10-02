using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver.Builders;
using SAIG.PS.Swampy.MongoDataAccess;
using SAIG.PS.Swampy.Service.Entities.Endpoint;
using Environment = SAIG.PS.Swampy.Service.Entities.Environment;

namespace SAIG.PS.Swampy.Service.QueryObjects
{
    public class EndpointsWithMatchingKeyQuery : QueryBase<EndpointBase>
    {
        public string EnvironmentName { get; set; }
        public List<string> Keys { get; set; }

        #region Overrides of QueryBase<EndpointBase>

        public override IQueryable<EndpointBase> GetQuery()
        {
            var environment = Session.All<Environment>();

            /*var environment = Session.All<Environment>().Where(x => x.Name == EnvironmentName);

            if (!environment.Any())
                return new List<EndpointBase>().AsQueryable();

            return environment.First().Endpoints.Where(x => Keys.Contains(x.Key)).AsQueryable();*/
            return null;
        }

        #endregion
    }
}
