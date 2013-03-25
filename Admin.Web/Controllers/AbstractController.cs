using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate;
using Swampy.Business.Infrastructure.Abstractions;

namespace Swampy.Admin.Web.Controllers
{
    public class AbstractController : Controller
    {
        public ISession Session;

        public Action<Command> AlternativeExecuteCommand { get; set; }
        public Func<Command, object> AlternativeExecuteCommandWithResult { get; set; }
     

        public void ExecuteCommand(Command cmd)
        {
            if (AlternativeExecuteCommand != null)
                AlternativeExecuteCommand(cmd);
            else
                Default_ExecuteCommand(cmd);
        }

        public TResult ExecuteCommand<TResult>(Command<TResult> cmd)
        {
            if (AlternativeExecuteCommandWithResult != null)
                return (TResult)AlternativeExecuteCommandWithResult(cmd);
            return Default_ExecuteCommand(cmd);
        }

        protected void Default_ExecuteCommand(Command cmd)
        {
            cmd.Session = Session;
            cmd.Execute();
        }

        protected TResult Default_ExecuteCommand<TResult>(Command<TResult> cmd)
        {
            ExecuteCommand((Command)cmd);
            return cmd.Result;
        }
    }
}