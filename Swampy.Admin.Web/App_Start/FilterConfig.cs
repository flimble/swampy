using System.Web.Mvc;
using Swampy.Admin.Web.ActionFilters;

namespace Swampy.Admin.Web.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new NHibernateActionFilter());
        }
    }
}
