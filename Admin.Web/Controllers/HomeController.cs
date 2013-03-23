using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using Swampy.Admin.Web.Models;
using Swampy.Admin.Web.Models.ReadModels;
using Environment = Swampy.Business.DomainModel.Entities.Environment;

namespace Swampy.Admin.Web.Controllers
{
    //[Authorize]
    public class HomeController : AbstractController
    {
     
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var names = from e in Session.Query<Environment>()
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


    }
}
