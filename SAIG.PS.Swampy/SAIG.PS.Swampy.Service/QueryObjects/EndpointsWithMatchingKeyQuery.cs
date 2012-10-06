using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using SAIG.PS.Swampy.MongoDataAccess;
using SAIG.PS.Swampy.Service.Entities.Endpoint;
using Environment = SAIG.PS.Swampy.Service.Entities.Environment;

namespace SAIG.PS.Swampy.Service.QueryObjects
{
    public class EndpointsWithMatchingKeyQuery : IQueryObject<EndpointBase>
    {
        public string EnvironmentName { get; set; }
        public List<string> Keys { get; set; }

        #region Overrides of QueryBase<EndpointBase>

        public IMongoQuery GetQuery()
        {
            /*var query =
                Query<Environment>.(x => x.Endpoints, Keys);

            return query;*/
            return null;
        }

        #endregion
    }
}
