using System.Linq;

namespace SAIG.PS.Swampy.MongoDataAccess
{
    public interface IQueryObject<T>
    {
        IQueryable<T> GetQuery();

        void SetSession(ISession currentSession);
    }
}
