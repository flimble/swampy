using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using Swampy.Admin.Web.App_Start;
using Swampy.Admin.Web.Controllers;
using Swampy.Business.Infrastructure.NHibernate;

namespace Swampy.Admin.Web.ActionFilters
{
    public class NHibernateActionFilter : ActionFilterAttribute
    {
             
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionController = filterContext.Controller as AbstractController;

            if (sessionController == null)
                return;

            sessionController.Session = NHibernateConfig.SessionFactory.OpenSession();
            sessionController.Session.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var sessionController = filterContext.Controller as AbstractController;

            if (sessionController == null)
                return;

            using (var session = sessionController.Session)
            {
                if (session == null)
                    return;

                if (!session.Transaction.IsActive)
                    return;

                if (filterContext.Exception != null)
                    session.Transaction.Rollback();
                else
                    session.Transaction.Commit();
            }

        }
    }
}