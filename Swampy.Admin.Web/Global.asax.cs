using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Swampy.Admin.Web.App_Start;
using Swampy.Admin.Web.Bootstrappers;

namespace Swampy.Admin.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            NHibernateConfig.Configure();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ValidationConfig.Configure();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            
        }
    }
}