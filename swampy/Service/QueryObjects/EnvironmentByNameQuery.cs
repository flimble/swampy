using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Swampy.MongoDataAccess;
using Environment = Swampy.Service.Entities.Environment;
using Swampy.Service.Entities.Endpoint;

namespace Swampy.Service.QueryObjects
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
