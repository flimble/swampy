using System.Linq;
using MongoDB.Driver;

namespace SAIG.PS.Swampy.MongoDataAccess
{
    public interface IQueryObject<T>
    {
        IMongoQuery GetQuery();
    }
}
