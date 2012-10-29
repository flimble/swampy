using System.Linq;
using MongoDB.Driver;

namespace Swampy.MongoDataAccess
{
    public interface IQueryObject<T>
    {
        IMongoQuery GetQuery();
    }
}
