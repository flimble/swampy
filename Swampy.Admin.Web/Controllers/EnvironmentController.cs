using System.Linq;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using Swampy.Admin.Web.Models.Mappers;
using Swampy.Admin.Web.Models.Operation;
using Swampy.Admin.Web.Models.ReadModels;
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

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var names = from e in Session.Query<SwampyEnvironment>()
                                         .OrderBy(x => x.Name)
                        select e.Name;



            var model = new HomeReadModel
            {
                EnvironmentNames = names.ToList()
            };

            return View(model);

        }

        public ActionResult Detail(string environmentName)
        {


            var environments = this.Session.Query<SwampyEnvironment>();

            var currentEnvironment = environments.Single(x => x.Name == environmentName);

            var model = new EnvironmentOutput()
                {
                    Id = currentEnvironment.Id,
                    Name = currentEnvironment.Name,
                    Domain = currentEnvironment.Domain
                };
            
            return View(model);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Edit", new EnvironmentInput());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var environment = Session.Get<SwampyEnvironment>(id);

            var model = new EnvironmentInput
            {
                Domain = environment.Domain,
                Id = environment.Id,
                Name = environment.Name
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EnvironmentInput operation)
        {
            if (!ModelState.IsValid)
                return View(operation);

            SwampyEnvironment environment = null;
            if (operation.Id.HasValue)
            {
                environment = Session.Get<SwampyEnvironment>(operation.Id.Value);
            }
            else
            {
                environment = new SwampyEnvironment(operation.Name);
            }

            environment.Domain = operation.Domain;
            environment.Name = operation.Name;

            Session.SaveOrUpdate(environment);

            return RedirectToAction("Index");
        }
    }
}