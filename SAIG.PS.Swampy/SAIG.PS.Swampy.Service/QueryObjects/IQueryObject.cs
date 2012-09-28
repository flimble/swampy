using System.Linq;

namespace SAIG.PS.Swampy.Service.QueryObjects
{
    /// <summary>
    /// Interface for all query objects
    /// </summary>
    public interface IQueryObject<T, V>
    {
        IQueryable<T> GetQuery(IQueryable<V> inputQuery);
    }
}