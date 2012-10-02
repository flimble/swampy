using System;
using System.Linq;
using System.Web.Mvc;
using SAIG.PS.Swampy.Admin.MVC.Models;
using SAIG.PS.Swampy.MongoDataAccess;
using SAIG.PS.Swampy.Service.Entities.Endpoint;
using SAIG.PS.Swampy.Service.QueryObjects;
using Environment = SAIG.PS.Swampy.Service.Entities.Environment;


namespace SAIG.PS.Swampy.Admin.MVC.Controllers
{
    public class EnvironmentController : Controller
    {
        private readonly ISession _session;


        public EnvironmentController()
        {
            _session = new Session("mongodb://localhost/?safe=true", "swampyintegrationtests");
        }

        public ActionResult Index(string environmentName)
        {
            var environment = _session.Query(new EnvironmentByNameQuery { EnvironmentName = environmentName }).Single();

            

            var modelEndpoints = from ep in environment.Endpoints
                                 select ToEndpointViewModel(ep);

            var model = new EnvironmentViewModel
                            {
                                Endpoints = modelEndpoints.ToList(),
                                environmentName = environment.Name
                            };



            return View(model);
        }

        public EnvironmentViewModel.EndpointViewModel ToEndpointViewModel(EndpointBase toMap)
        {
            var result = new EnvironmentViewModel.EndpointViewModel
                             {
                                 Key = toMap.Key,
                                 Value = toMap.Value,
                                 Type = toMap.TypeName,
                                 Description = toMap.Description
                             };

            return result;
        }
    }
}