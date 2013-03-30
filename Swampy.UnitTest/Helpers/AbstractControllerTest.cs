using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Rhino.Mocks;
using Swampy.Admin.Web.App_Start;
using Swampy.Admin.Web.Controllers;
using Swampy.Business.Infrastructure.NHibernate;
using Swampy.UnitTest.Queries;

namespace Swampy.UnitTest.Admin.MVC.Controllers
{

    public class AbstractControllerTest : AbstractNHibernateDatabaseTest
    {
      
        protected ControllerContext ControllerContext { get; set; }


        protected TController ExecuteAction<TController>(Action<TController> action) where TController : AbstractController, new()
        {
            var controller = new TController { Session=this.session };

            var httpContext = MockRepository.GenerateStub<HttpContextBase>();
            httpContext.Stub(x => x.Response).Return(MockRepository.GenerateStub<HttpResponseBase>());
            this.ControllerContext = new ControllerContext(httpContext, new RouteData(), controller);
            controller.ControllerContext = ControllerContext;


            using (var tx = session.BeginTransaction())
            {
                action(controller);
                tx.Commit();
            }

            return controller;
        }

        protected void SetupData(Action<ISession> action)
        {
            using (var tx = session.BeginTransaction())
            {
                action(session);
                tx.Commit();
            }

        }

    }
}
