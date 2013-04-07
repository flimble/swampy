using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using Swampy.Admin.Web.Models;
using Swampy.Admin.Web.Models.Operation;
using Swampy.Admin.Web.Models.Read;
using Swampy.Business.DomainModel.Entities;


namespace Swampy.Admin.Web.Controllers
{
    public class EnvironmentController : AbstractController
    {        

        [HttpGet]
        public ActionResult Index()
        {

            var names = from e in Session.Query<SwampyEnvironment>()
                                         .OrderBy(x => x.Name)
                        select new KeyValuePair<string, string>(e.Name, e.Description);

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

            var model = Mapper.Map<SwampyEnvironment, EnvironmentReadModel>(currentEnvironment);

            return View(model);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Edit", new EnvironmentInputModel());
        }

        [HttpGet]
        public ActionResult Edit(int environmentId)
        {
            var environment = Session.Get<SwampyEnvironment>(environmentId);

            var model = Mapper.Map<SwampyEnvironment, EnvironmentInputModel>(environment);


            return View(model);
        }

        [HttpPost]
        public ActionResult AddConfigurationItem(ConfigurationItemInputModel item)
        {
            if (!ModelState.IsValid)
                return Edit(item.EnvironmentId);

            var environment = Session.Load<SwampyEnvironment>(item.EnvironmentId);

            var newConfigurationItem = this.Mapper.Map<ConfigurationItemInputModel, ConfigurationItem>(item);
            //newConfigurationItem.SwampyEnvironment = environment;
            environment.ConfigurationItems.Add(newConfigurationItem);

            Session.SaveOrUpdate(environment);

            return RedirectToAction("Detail", "Environment", new { environmentName=environment.Name} );

        }


        [HttpPost]
        public ActionResult Edit(EnvironmentInputModel operation)
        {
            if (!ModelState.IsValid)
                return View(operation);

            SwampyEnvironment environment = null;
            if (operation.Id.HasValue)
            {
                environment = Session.Load<SwampyEnvironment>(operation.Id.Value);
            }
            else
            {
                environment = new SwampyEnvironment(operation.Name);

                if (Session.Query<SwampyEnvironment>().Any(x => x.Name == operation.Name))
                {
                    ModelState.AddModelError("Name", "Duplicate name already found. Cannot have two environments with the same name");
                    return View(operation);
                }
            }

            Mapper.Map(operation, environment);

          
            Session.SaveOrUpdate(environment);


            return RedirectToAction("Index");
        }

        
    }
}
