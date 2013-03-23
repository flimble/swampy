using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using Swampy.Admin.Web.Models.Mappers;
using Swampy.Admin.Web.Models.OperationModels;
using CreateEnvironmentOperationModel = Swampy.Admin.Web.Models.OperationModels.Environment.CreateEnvironmentOperationModel;
using Environment = Swampy.Business.DomainModel.Entities.Environment;
using System.Collections.Generic;
using System;
using System.Reflection;
using Swampy.Domain.Entities.Endpoint;


namespace Swampy.Admin.Web.Controllers
{
    public class EnvironmentController : AbstractController
    {


        protected List<string> GetEndpointTypes()
        {
            var endpointTypes = Assembly
               .GetAssembly(typeof(EndpointBase))
               .GetTypes()
               .Where(x => x.IsSubclassOf(typeof(EndpointBase)) && !x.IsAbstract)
               .Select(x => x)
               .ToList();

            var a = new List<string>();

            foreach (var type in endpointTypes)
            {
                var endpoint = Activator.CreateInstance(type) as EndpointBase;
                string name = endpoint.TypeName;

                a.Add(name);
            }

            return a;
        }

        public ActionResult Index(string environmentName)
        {


            var environments = this.Session.Query<Environment>();

            var currentEnvironment = environments.Single(x => x.Name == environmentName);
            var allEnvironments = from e in environments select e.Name;
            
                                  

            var model = new EnvironmentViewModelMapper()
                .Map(currentEnvironment);

            model.allEnvironments = allEnvironments.ToList();
            model.EndpointTypes = GetEndpointTypes();

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