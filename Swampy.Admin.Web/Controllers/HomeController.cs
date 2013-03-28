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
            return RedirectToAction("Index", "Environment");
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }


       
    }

}


