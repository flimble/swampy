using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAIG.PS.Swampy.Admin.MVC.Models;
using SAIG.PS.Swampy.MongoDataAccess;
using Environment = SAIG.PS.Swampy.Service.Entities.Environment;

namespace SAIG.PS.Swampy.Admin.MVC.Controllers
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
