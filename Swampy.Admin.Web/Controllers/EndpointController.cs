﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using NHibernate.Linq;
using Swampy.Admin.Web.Models.OperationModels;
using Swampy.Admin.Web.Models.OperationModels.Endpoint;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.Controllers
{
    public class EndpointController : AbstractController
    {


        protected IDictionary<string, Type> GetEndpointTypes()
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
        public ActionResult Edit(string environmentName)
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
        public ActionResult Edit(CreateEndpoint newEndpoint)
        {
            ModelState.AddModelError("Description", "Cannot be empty");

            if (!ModelState.IsValid)
            {
                //var model = RebuildModel(newEndpoint);
                return View(newEndpoint);
            }


            var environment =
                this.Session.Query<SwampyEnvironment>().Single(
                    x => x.Name == newEndpoint.EnvironmentName);


            var toAdd = new ConfigurationItem(newEndpoint.Endpoint.Name, newEndpoint.Endpoint.Value,
                                              ConfigurationItemType.Simple, environment);
            environment.ConfigurationItems.Add(toAdd);

            this.Session.SaveOrUpdate(environment);

            return RedirectToAction("Index", "Environment", new { environmentName = newEndpoint.EnvironmentName });
        }

        public CreateEndpoint RebuildModel(CreateEndpoint postedEndpoint)
        {
            postedEndpoint.EndpointTypes = GetEndpointTypes();
            postedEndpoint.Endpoint = new CreateSimpleEndpoint();

            return postedEndpoint;
        }


        public ActionResult Save(ConfigurationItem data)
        {
            var endpoint = this.Session.Query<ConfigurationItem>().Single(
                x => x.Name == data.Name
                );

            return RedirectToAction("Index", "Home");


        }

        public ActionResult Edit(string environment, string key)
        {
            var environmentObject = this.Session.Query<SwampyEnvironment>().Single(
                            x => x.Name == environment
                            );

            var endpoint = environmentObject.ConfigurationItems.Single(x => x.Name == key) as ConfigurationItem;

            return View("Edit", endpoint);

        }
    }
}
