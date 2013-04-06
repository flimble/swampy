using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate;
using Rhino.Mocks;
using Swampy.Admin.Web.Controllers;
using Swampy.UnitTest.Helpers;

namespace Swampy.UnitTest.Admin.MVC.Controllers
{

    public class AbstractControllerTest : AbstractNHibernateDatabaseTest
    {
        public AbstractControllerTest(TheDatabase requirements) : base(requirements)
        {
            
        }

        protected ControllerContext ControllerContext { get; set; }

        protected TController ExecuteAction<TController>(Action<TController> action) where TController : AbstractController, new()
        {
            var controller = new TController { Session=this.Session };

            var httpContext = MockRepository.GenerateStub<HttpContextBase>();
            httpContext.Stub(x => x.Response).Return(MockRepository.GenerateStub<HttpResponseBase>());
            this.ControllerContext = new ControllerContext(httpContext, new RouteData(), controller);
            controller.ControllerContext = ControllerContext;


            using (var tx = Session.BeginTransaction())
            {
                action(controller);
                tx.Commit();
            }

            return controller;
        }

        protected void SetupData(Action<ISession> action)
        {
            using (var tx = Session.BeginTransaction())
            {
                action(Session);
                tx.Commit();
            }

        }

    }
}
