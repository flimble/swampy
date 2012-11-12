using System.Linq;
using System.Web.Mvc;
using Swampy.Admin.Web.Models.Mappers;
using Swampy.Admin.Web.Models.OperationModels;
using CreateEnvironmentOperationModel = Swampy.Admin.Web.Models.OperationModels.Environment.CreateEnvironmentOperationModel;
using Environment = Swampy.Domain.Entities.Environment;


namespace Swampy.Admin.Web.Controllers
{
    public class EnvironmentController : BaseDocumentStoreController
    {

        public ActionResult Index(string environmentName)
        {


            var environments = this.DocumentSession.Query<Environment>();

            var currentEnvironment = environments.Single(x => x.Name == environmentName);
            var allEnvironments = from e in environments select e.Name;
            
                                  

            var model = new EnvironmentViewModelMapper()
                .Map(currentEnvironment);

            model.allEnvironments = allEnvironments.ToList();

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