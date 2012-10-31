using System.Linq;
using System.Web.Mvc;
using Swampy.Admin.Web.Models;
using Environment = Swampy.Domain.Entities.Environment;

namespace Swampy.Admin.Web.Controllers
{
    public class HomeController : BaseDocumentStoreController
    {
     

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var names = from e in this.DocumentSession.Query<Environment>()
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
