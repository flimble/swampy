using System.Linq;
using System.Web.Mvc;
using SAIG.PS.Swampy.Admin.MVC.Models.Mappers;
using SAIG.PS.Swampy.Admin.MVC.Models.OperationModels;
using SAIG.PS.Swampy.MongoDataAccess;
using SAIG.PS.Swampy.Service.QueryObjects;
using Environment = SAIG.PS.Swampy.Service.Entities.Environment;


namespace SAIG.PS.Swampy.Admin.MVC.Controllers
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