using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using SAIG.PS.Swampy.Admin.MVC.Models.OperationModels;
using SAIG.PS.Swampy.MongoDataAccess;
using SAIG.PS.Swampy.Service.Entities.Endpoint;
using SAIG.PS.Swampy.Service.QueryObjects;

namespace SAIG.PS.Swampy.Admin.MVC.Controllers
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
            var model = new CreateEndpointOperationModel
                {
                    EnvironmentName = environmentName
                };



            model.EndpointTypes = GetEndpointTypes();

            

            return View(model);
        }

        public ActionResult Save(CreateEndpointOperationModel newEndpoint)
        {
            if(!ModelState.IsValid)
            {
                newEndpoint.EndpointTypes = GetEndpointTypes();

                return View("Create", newEndpoint);
            }
            

            var environment = _session.QueryOne(new EnvironmentByNameQuery
                {
                    EnvironmentName = newEndpoint.EnvironmentName
                });

            




            var toAdd = new SimpleEndpoint
                {
                    Description = newEndpoint.Description,
                    Key = newEndpoint.Name,
                    Value = newEndpoint.Value
                };

            environment.Endpoints.Add(toAdd);

            _session.Save(environment);

            return RedirectToAction("Index", "Environment", new { environmentName = newEndpoint.EnvironmentName } );
        }

    }
}
