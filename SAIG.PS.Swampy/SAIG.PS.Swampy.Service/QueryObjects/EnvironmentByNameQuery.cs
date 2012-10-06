using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using SAIG.PS.Swampy.MongoDataAccess;
using Environment = SAIG.PS.Swampy.Service.Entities.Environment;
using SAIG.PS.Swampy.Service.Entities.Endpoint;

namespace SAIG.PS.Swampy.Service.QueryObjects
{
    public class EnvironmentByNameQuery : IQueryObject<Environment>
    {
        public string EnvironmentName { get; set; }

        

        public IMongoQuery GetQuery()
        {
            var query = Query<Environment>.EQ(x => x.Name, EnvironmentName);
            return query;
        }

       
    }
}
