using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAIG.PS.Swampy.MongoDataAccess;
using Environment = SAIG.PS.Swampy.Service.Entities.Environment;
using SAIG.PS.Swampy.Service.Entities.Endpoint;

namespace SAIG.PS.Swampy.Service.QueryObjects
{
    public class EnvironmentByNameQuery : QueryBase<Environment>, IQueryObject<Environment>
    {
        public string EnvironmentName { get; set; }

        

        public override IQueryable<Environment> GetQuery()
        {
            var all = Session.All<Environment>();
            
            var query = from e in all
                        where e.Name == this.EnvironmentName
                        select e;

            return query;
        }

       
    }
}
