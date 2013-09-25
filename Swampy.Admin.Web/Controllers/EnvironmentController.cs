using System;
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

            return View("Detail", model);

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
        public ActionResult Delete(int environmentId, int configurationItemId)
        {
            var environment = Session.Get<SwampyEnvironment>(environmentId);
            var toDelete = environment.ConfigurationItems.Single(x => x.Id == configurationItemId);

            environment.ConfigurationItems.Remove(toDelete);

            Session.Save(environment);

            return RedirectToAction("Detail", "Environment", new { environmentName = environment.Name});
        }


        [HttpPost]
        public ActionResult AddConfigurationItem(ConfigurationItemInputModel item)
        {
            var environment = Session.Load<SwampyEnvironment>(item.EnvironmentId);

            if (item.Id.HasValue)
            {
                var configurationItem = Session.Load<ConfigurationItem>(item.Id.Value);
                var updatedItem = Mapper.Map(item, configurationItem);

                Session.SaveOrUpdate(updatedItem);



            }
            else
            {
                var newConfigurationItem = this.Mapper.Map<ConfigurationItemInputModel, ConfigurationItem>(item);

                environment.ConfigurationItems.Add(newConfigurationItem);
                Session.SaveOrUpdate(environment);


            }

            return RedirectToAction("Detail", "Environment", new { environmentName = environment.Name });

        }

        [HttpGet]
        public ActionResult GetConfigurationItem(int configurationItemId, int environmentId)
        {
            ViewBag.Title = "Edit ConfigurationItem";

            var item = Session.Load<ConfigurationItem>(configurationItemId);

            var model = Mapper.Map<ConfigurationItem, ConfigurationItemInputModel>(item);
            model.EnvironmentId = environmentId;

            return View("CreateConfigurationItemPopup", model);
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
