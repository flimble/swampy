using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using Swampy.Admin.Web.Models;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.Controllers
{
    public class ConfigurationItemController : AbstractController
    {
        public ConfigurationItemController()
        {
                   
        }

        public JsonResult CalculateActualValue(ConfigurationItemInputModel model)
        {
            var entity = Mapper.Map<ConfigurationItemInputModel, ConfigurationItem>(model);

            IList<ConfigurationItem> items =
                Session.Query<ConfigurationItem>().Where(x => x.StoreAsToken).ToList();

            entity.Hydrate(items);


            return new JsonResult() { Data=entity.HydratedValue};
        }

     
    }
}