using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Swampy.Admin.Web.Infrastructure.ActionFilters
{
    public class HandleJsonErrorsActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var modelState = (filterContext.Controller as Controller).ModelState;
                if (!modelState.IsValid)
                {
                    var errors = modelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new
                            {
                                x.Key,
                                x.Value.Errors
                            });
                    filterContext.Result = new JsonResult
                        {
                            Data = new {isvalid = false, errors = errors}
                        };
                }
            }
        }
    }
}