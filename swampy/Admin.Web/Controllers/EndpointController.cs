using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Swampy.Admin.Web.Models.OperationModels;
using Swampy.Admin.Web.Models.OperationModels.Endpoint;
using Swampy.Service.Entities.Endpoint;

namespace Swampy.Admin.Web.Controllers
{
    public class EndpointController : BaseDocumentStoreController
    {
     

        protected IDictionary<string, Type> GetEndpointTypes()
        {
            var endpointTypes = Assembly
               .GetAssembly(typeof(EndpointBase))
               .GetTypes()
               .Where(x => x.IsSubclassOf(typeof(EndpointBase)) && !x.IsAbstract)
               .Select(x => x)
               .ToList();

            var a = new Dictionary<string, Type>();

            foreach (var type in endpointTypes)
            {
                var endpoint = Activator.CreateInstance(type) as EndpointBase;
                string name = endpoint.TypeName;

                a.Add(name, type);
            }

            return a;
        }

        public ActionResult Create(string environmentName)
        {
            var model = new CreateEndpoint
                {
                    EnvironmentName = environmentName,
                    Endpoint = new CreateSimpleEndpoint()
                };



            model.EndpointTypes = GetEndpointTypes();

            this.DocumentSession.Store(model);
            

            return View(model);
        }

        public ActionResult Save(CreateEndpoint newEndpoint)
        {
            if(!ModelState.IsValid)
            {
                newEndpoint.EndpointTypes = GetEndpointTypes();
                newEndpoint.Endpoint = new CreateSimpleEndpoint();

                return View("Create", newEndpoint);
            }


            var environment =
                this.DocumentSession.Query<Swampy.Service.Entities.Environment>().Single(
                    x => x.Name == newEndpoint.EnvironmentName);

 


            var endpoint = newEndpoint.Endpoint as CreateSimpleEndpoint;

            var toAdd = new SimpleEndpoint
                {
                    Description = newEndpoint.Endpoint.Description,
                    Key = newEndpoint.Endpoint.Name,
                    Value = endpoint.Value
                };

            environment.Endpoints.Add(toAdd);

            this.DocumentSession.SaveChanges();

            return RedirectToAction("Index", "Environment", new { environmentName = newEndpoint.EnvironmentName } );
        }

    }
}
