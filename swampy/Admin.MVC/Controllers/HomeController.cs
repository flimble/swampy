using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Swampy.Admin.MVC.Models;
using Swampy.MongoDataAccess;
using Environment = Swampy.Service.Entities.Environment;

namespace Swampy.Admin.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession _session;

        public HomeController(ISession session)
        {
            _session = session;
        }


        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var names = from e in _session.All<Environment>()
                        select e.Name;


            var model = new HomeReadModel
                            {
                                EnvironmentNames = names.ToList()
                            };

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }


    }
}
