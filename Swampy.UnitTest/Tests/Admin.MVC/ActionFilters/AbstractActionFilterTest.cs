using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;
using Swampy.Admin.Web.Controllers;

namespace Swampy.UnitTest.Tests.Admin.MVC.ActionFilters
{
    public abstract class AbstractActionFilterTest
    {
        protected ActionExecutedContext ActionExecutedContext { get; set; }
        protected ActionExecutingContext ActionExecutingContext { get; set; }


        [SetUp]
        public void Setup()
        {
            this.ActionExecutedContext = MockRepository.GenerateStub<ActionExecutedContext>();
            this.ActionExecutingContext = MockRepository.GenerateStub<ActionExecutingContext>();  
        }


        protected void ExecuteActionFilter<TActionFilter>(TActionFilter filter, ISession session, Action<TActionFilter> action) where TActionFilter : ActionFilterAttribute, new()
        {
            var controller = MockRepository.GenerateStub<AbstractController>();
            controller.Session = session;

            var actionFilter = filter;

            ActionExecutedContext.Controller = controller;
            ActionExecutingContext.Controller = controller;
          
            action(actionFilter);            
        }
    }
}
