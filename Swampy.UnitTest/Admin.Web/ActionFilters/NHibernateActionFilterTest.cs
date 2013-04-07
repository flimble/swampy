using System;
using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;
using Swampy.Admin.Web.ActionFilters;
using Swampy.Admin.Web.Controllers;

namespace Swampy.UnitTest.Tests.Admin.MVC.ActionFilters
{
    [TestFixture]
    public class NHibernateActionFilterTest : AbstractActionFilterTest
    {
        private ISessionFactory _mockSessionFactory;
        private ISession _mockSession;

        [SetUp]
        public void Setup()
        {
            _mockSessionFactory = MockRepository.GenerateStub<ISessionFactory>();
            _mockSession = MockRepository.GenerateStub<ISession>();
            _mockSession.Stub(x => x.Transaction.IsActive).Return(true);
            _mockSessionFactory.Stub(x => x.OpenSession()).Return(_mockSession);
        }


      
        [Test]
        public void actionexecuted_rolls_back_nhibernate_transaction_on_error()
        {
            //arrange            
            _mockSession.Stub(x => x.Transaction.IsActive).Return(true);
            _mockSession.Expect(x => x.Transaction.Rollback());
            this.ActionExecutedContext.Exception = new NotImplementedException();

            var controller = MockRepository.GenerateStub<AbstractController>();
            controller.Session = _mockSession;

            //act
            ExecuteActionFilter(new NHibernateActionFilter(_mockSessionFactory), controller, x => x.OnActionExecuted(this.ActionExecutedContext));

            //assert
            _mockSession.VerifyAllExpectations();

        }

        [Test]
        public void actionexecuted_no_active_controller_session_do_not_modify_transaction()
        {
            //arrange                        
            var controller = MockRepository.GenerateStub<AbstractController>();
            controller.Session = null;

            //act
            ExecuteActionFilter(new NHibernateActionFilter(_mockSessionFactory), controller, x => x.OnActionExecuted(this.ActionExecutedContext));

            //assert
            _mockSession.AssertWasNotCalled(x=>x.Transaction.Commit());
            _mockSession.AssertWasNotCalled(x => x.Transaction.Rollback());

        }

        [Test]
        public void actionexecuted_commits_nhibernate_transaction_on_no_error()
        {
            //arrange            
            _mockSession.Stub(x => x.Transaction.IsActive).Return(true);
            _mockSession.Expect(x => x.Transaction.Commit());

            var controller = MockRepository.GenerateStub<AbstractController>();
            controller.Session = _mockSession;

            //act            
            ExecuteActionFilter(new NHibernateActionFilter(_mockSessionFactory), controller, x => x.OnActionExecuted(this.ActionExecutedContext));

            //assert
            _mockSession.VerifyAllExpectations();

        }



        [Test]
        public void actionexecuting_begins_nhibernate_transaction()
        {   
            //arrange            
            _mockSession.Stub(x => x.BeginTransaction()).Return(MockRepository.GenerateStub<ITransaction>());
            _mockSession.Expect(x => x.BeginTransaction());            

            //act
            ExecuteActionFilter(new NHibernateActionFilter(_mockSessionFactory), x => x.OnActionExecuting(this.ActionExecutingContext));

            //assert
            _mockSession.VerifyAllExpectations();


        }
    }
}
