using System.Linq;

namespace SAIG.PS.Swampy.Service.QueryObjects
{
    public interface IQueryObject
    {
        IQueryable GetQuery();
    }
}