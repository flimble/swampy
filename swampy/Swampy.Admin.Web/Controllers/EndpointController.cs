using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Swampy.Admin.Web.Models.OperationModels;
using Swampy.Admin.Web.Models.OperationModels.Endpoint;
using Swampy.MongoDataAccess;
using Swampy.Service.Entities.Endpoint;
using Swampy.Service.QueryObjects;

namespace Swampy.Admin.Web.Controllers
{
    public class EndpointController : Controller
    {
       private readonly ISession _session;

        public EndpointController(ISession session)
        {
            _session = session;
        }

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
            

            var environment = _session.QueryOne(new EnvironmentByNameQuery
                {
                    EnvironmentName = newEndpoint.EnvironmentName
                });


            var endpoint = newEndpoint.Endpoint as CreateSimpleEndpoint;

            var toAdd = new SimpleEndpoint
                {
                    Description = newEndpoint.Endpoint.Description,
                    Key = newEndpoint.Endpoint.Name,
                    Value = endpoint.Value
                };

            environment.Endpoints.Add(toAdd);

            _session.Save(environment);

            return RedirectToAction("Index", "Environment", new { environmentName = newEndpoint.EnvironmentName } );
        }

    }
}
