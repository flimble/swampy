using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Swampy.Admin.Web.Models.OperationModels;
using Swampy.Admin.Web.Models.OperationModels.Endpoint;
using Swampy.Domain.Entities.Endpoint;
using Environment = Swampy.Domain.Entities.Environment;

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

        /*[HttpGet]
        public ActionResult Detail(string id)
        {
            var model = this.DocumentSession.Query<EndpointBase>()
                .Single(x => x.Id == id);

            return View(model);
        }*/

        /*[HttpPut]
        public ActionResult Create()
        {
            
        }*/

        [HttpGet]
        public ActionResult Create(string environmentName)
        {
            var model = new CreateEndpoint
                {
                    EnvironmentName = environmentName,
                    Endpoint = new CreateSimpleEndpoint()
                };



            model.EndpointTypes = GetEndpointTypes();            

            return View(model);
        }


        [HttpPost]
        public ActionResult Create(CreateEndpoint newEndpoint)
        {
            ModelState.AddModelError("Description", "Cannot be empty");

            if (!ModelState.IsValid)
            {
                var model = RebuildModel(newEndpoint);
                return View("Create", model);
            }


            var environment =
                this.DocumentSession.Query<Environment>().Single(
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

            return RedirectToAction("Index", "Environment", new { environmentName = newEndpoint.EnvironmentName });
        }

        public CreateEndpoint RebuildModel(CreateEndpoint postedEndpoint)
        {
            postedEndpoint.EndpointTypes = GetEndpointTypes();
            postedEndpoint.Endpoint = new CreateSimpleEndpoint();

            return postedEndpoint;
        }



    }
}
