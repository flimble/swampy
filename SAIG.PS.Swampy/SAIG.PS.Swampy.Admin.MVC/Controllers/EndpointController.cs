using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAIG.PS.Swampy.Admin.MVC.Models.Operation;
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

        public ActionResult Create(string environmentName)
        {
            var model = new CreateEndpointOperationModel
                {
                    EnvironmentName = environmentName
                };

            return View(model);
        }

        public ActionResult Save(CreateEndpointOperationModel newEndpoint)
        {
            
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
