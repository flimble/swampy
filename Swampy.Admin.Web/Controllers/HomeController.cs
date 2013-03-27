using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using Swampy.Admin.Web.Models;
using Swampy.Admin.Web.Models.ReadModels;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.Controllers
{
    //[Authorize]
    public class HomeController : AbstractController
    {

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var names = from e in Session.Query<SwampyEnvironment>()
                                         .OrderBy(x => x.Name)
                        select e.Name;



            var model = new HomeReadModel
                {
                    EnvironmentNames = names.ToList()
                };

            return View(model);

        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }


        public ActionResult Test(int i)
        {
            return RedirectToAction("Test", new TestViewModel());
        }

        public ActionResult Test(TestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index");

        }
    }

    public class TestViewModel
    {
        public SelectListItem SelectedValue { get; set; }

        public SelectList PossibleValues { get; set; }

        [Required]
        public string WillFail { get; set; }
    }


}


