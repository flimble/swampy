using System.Linq;
using System.Web.Mvc;
using Swampy.Admin.MVC.Models.Mappers;
using Swampy.Admin.MVC.Models.OperationModels;
using Swampy.MongoDataAccess;
using Swampy.Service.QueryObjects;
using Environment = Swampy.Service.Entities.Environment;


namespace Swampy.Admin.MVC.Controllers
{
    public class EnvironmentController : Controller
    {
        private readonly ISession _session;


        public EnvironmentController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index(string environmentName)
        {
            var environment = _session.QueryOne(new EnvironmentByNameQuery { EnvironmentName = environmentName });


            var allEnvironmnets = from e in _session.All<Environment>()
                                  select e.Name; 

            var model = new EnvironmentViewModelMapper()
                .Map(environment);

            model.allEnvironments = allEnvironmnets.ToList();

            return View(model);
        }

        public ActionResult Create(CreateEnvironmentOperationModel operation)
        {
          
              if(!string.IsNullOrWhiteSpace(operation.environmentName))
              {
                  var environment = new Environment(operation.environmentName);


              }

            return null;
        }
       
    }
}