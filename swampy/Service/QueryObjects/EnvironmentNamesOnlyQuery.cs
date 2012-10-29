using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Swampy.MongoDataAccess;
using Environment = Swampy.Service.Entities.Environment;

namespace Swampy.Service.QueryObjects
{
    public class EnvironmentNamesOnlyQuery : IQueryObject<Environment>
    {
        #region Implementation of IQueryObject<Environment>

        public IMongoQuery GetQuery()
        {
            throw new NotImplementedException();


        }

        #endregion
    }
}
