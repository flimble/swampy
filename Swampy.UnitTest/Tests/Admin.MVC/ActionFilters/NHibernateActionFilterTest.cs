using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;
using Swampy.Admin.Web.ActionFilters;
using Swampy.Admin.Web.App_Start;
using Swampy.Admin.Web.Controllers;

namespace Swampy.UnitTest.Tests.Admin.MVC.ActionFilters
{
    [TestFixture]
    public class NHibernateActionFilterTest
    {        

        public ActionExecutedContext ActionExecutedContext()
        {
            var filterContextMock = MockRepository.GenerateStub<ActionExecutedContext>();
            filterContextMock.Result = MockRepository.GenerateStub<ViewResultBase>();
            filterContextMock.Controller = MockRepository.GenerateStub<AbstractController>();
            return filterContextMock;
        }
        
        //TODO: Complete unit tests for first Action Filter
        [Test]
        public void actionexecuted_rolls_back_nhibernate_transaction_on_error()
        {
            // arrange
            var mockSessionFactory = MockRepository.GenerateStub<ISessionFactory>();
            var mockSession = MockRepository.GenerateStub<ISession>();
            mockSession.Stub(x => x.Transaction.IsActive).Return(true);
            mockSessionFactory.Stub(x => x.OpenSession()).Return(mockSession);
            var underTest = new NHibernateActionFilter(mockSessionFactory);
            
            
            var viewResultMock = MockRepository.GenerateStub<ViewResultBase>();

            var filterContextMock = MockRepository.GenerateStub<ActionExecutedContext>();
            filterContextMock.Result = viewResultMock;
            var fakeController = MockRepository.GenerateStub<AbstractController>();
            fakeController.Session = mockSession;
            filterContextMock.Controller = fakeController;
            filterContextMock.Exception = new NotImplementedException();

            mockSession.Expect(x => x.Transaction.Rollback());

            // act
            underTest.OnActionExecuted(filterContextMock);

            //assert
            mockSession.VerifyAllExpectations();

        }


        [Test]
        public void actionexecuting_begins_nhibernate_transaction()
        {
            // arrange
            var mockSessionFactory = MockRepository.GenerateStub<ISessionFactory>();
            var mockSession = MockRepository.GenerateStub<ISession>();
            mockSessionFactory.Stub(x => x.OpenSession()).Return(mockSession);                   
            var underTest = new NHibernateActionFilter(mockSessionFactory);
            var fakeController = MockRepository.GenerateStub<AbstractController>();
            
            var filterContextMock = MockRepository.GenerateStub<ActionExecutingContext>();
            var viewResultMock = MockRepository.GenerateStub<ViewResultBase>();
            filterContextMock.Result = viewResultMock;
            filterContextMock.Controller = fakeController;

            mockSession.Expect(x => x.BeginTransaction());

            // act
            underTest.OnActionExecuting(filterContextMock);


            //assert
            mockSession.VerifyAllExpectations();


        }
    }

    public class FakeController : AbstractController
    {
        public FakeController(ISession session)
        {
            this.Session = session;
        }

        public ActionResult Index()
        {
            throw new ArgumentException();
        }
    }
}
