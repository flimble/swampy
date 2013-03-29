using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Swampy.Admin.Web.App_Start;
using Swampy.Admin.Web.Controllers;

namespace Swampy.UnitTest.Tests.Admin.MVC.Routing
{
    /// <summary>
    /// Tests for Routing specified in RouteConfig
    /// </summary>
    /// <remarks>Parameters are not tested as these are handled by the model binder not routing</remarks>
    [TestFixture]
    public class RouteConfigTest
    {

        [SetUp]
        public void SetUp()
        {
            var routes = RouteTable.Routes;
            routes.Clear();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        [Test]
        public void named_controller_default_index()
        {
            "~/environment".ShouldMapTo<EnvironmentController>(action => action.Index());
        }

        [Test]
        public void named_controller_named_index()
        {
            "~/environment/create".ShouldMapTo<EnvironmentController>(action => action.Create());
        }


        [Test]
        public void default_to_home_index()
        {
            "~/"
                .ShouldMapTo<HomeController>(action => action.Index());
        }
    }
}
