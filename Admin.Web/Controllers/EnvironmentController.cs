using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using Swampy.Admin.Web.Models.Mappers;
using Swampy.Business.DomainModel.Entities;
using CreateEnvironmentOperationModel = Swampy.Admin.Web.Models.OperationModels.Environment.CreateEnvironmentOperationModel;
using System;


namespace Swampy.Admin.Web.Controllers
{
    public class EnvironmentController : AbstractController
    {


        /*protected IDictionary<string, Type> GetEndpointTypes()
        {
            var endpointTypes = Assembly
               .GetAssembly(typeof(ConfigurationItem))
               .GetTypes()
               .Where(x => x.IsSubclassOf(typeof(AbstractEntity)) && !x.IsAbstract)
               .Select(x => x)
               .ToList();

            var a = new Dictionary<string, Type>();

            foreach (var type in endpointTypes)
            {
                var endpoint = Activator.CreateInstance(type) as ConfigurationItem;
                string name = endpoint.TypeName;

                a.Add(name, type);
            }

            return a;
        }*/

        public ActionResult Index(string environmentName)
        {


            var environments = this.Session.Query<SwampyEnvironment>();

            var currentEnvironment = environments.Single(x => x.Name == environmentName);
            var allEnvironments = from e in environments select e.Name;
            
                                  

            var model = new EnvironmentViewModelMapper()
                .Map(currentEnvironment);

            model.allEnvironments = allEnvironments.ToList();
            model.EndpointTypes = Enum.GetValues(typeof (ConfigurationItemType)).Cast<ConfigurationItemType>();

            return View(model);

        }

        public ActionResult Create(CreateEnvironmentOperationModel operation)
        {
          
              if(!string.IsNullOrWhiteSpace(operation.environmentName))
              {
                  var environment = new SwampyEnvironment(operation.environmentName);


              }

            return null;
        }


    }
}