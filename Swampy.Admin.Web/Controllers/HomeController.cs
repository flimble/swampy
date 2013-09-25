using System;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using System.Web.Mvc;
using Swampy.Admin.Web.Models;

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
        //TODO: Add a 'REAL' about page. Currently just using the readme.md to make sure it is maintained until version 1.0 release.
        public ActionResult About()
        {
            var baseDir = Server.MapPath("~/bin");
            var readmeFile = Path.Combine(baseDir, "readme.md");

            string fileText = System.IO.File.ReadAllText(readmeFile);

            var model = new AboutReadModel { Markdown = fileText };

            return View(model);
        }



    }

}


