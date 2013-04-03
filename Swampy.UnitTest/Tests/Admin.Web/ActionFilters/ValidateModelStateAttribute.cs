using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using Swampy.Admin.Web.ActionFilters;

namespace Swampy.UnitTest.Tests.Admin.MVC.ActionFilters
{
    [TestFixture]
    public class ValidateModelStateAttributeTest : AbstractActionFilterTest
    {
        [Test]
        public void modelstate_with_errors_stores_data_in_temporal_data_in_result()
        {
            var modelData = new ViewDataDictionary();
                    modelData.ModelState.AddModelError("Name", "Not a valid state for name");        
                                           
            ExecuteActionFilter(new ValidateModelStateAttribute(), x =>
                {                    
                    this.ActionExecutingContext.Controller.ViewData = modelData;
                    x.OnActionExecuting(this.ActionExecutingContext);
                });

            ViewResult result = this.ActionExecutingContext.Result as ViewResult;

            Assert.NotNull(result);
            Assert.AreEqual(modelData.ModelState, result.ViewData.ModelState);
            Assert.AreEqual(ActionExecutingContext.Controller.TempData, result.TempData);
        }

        [Test]
        public void modelstate_without_errors_no_change()
        {
          
            ExecuteActionFilter(new ValidateModelStateAttribute(), x => x.OnActionExecuting(this.ActionExecutingContext));
            ViewResult result = this.ActionExecutingContext.Result as ViewResult;

            Assert.IsNull(result);            
        }
    }
}
