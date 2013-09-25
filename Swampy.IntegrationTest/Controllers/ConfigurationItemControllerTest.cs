using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using Swampy.Admin.Web.App_Start;
using Swampy.Admin.Web.Controllers;
using Swampy.Admin.Web.Models;
using Swampy.Business.DomainModel.Entities;
using Swampy.UnitTest.Admin.MVC.Controllers;
using Swampy.UnitTest.Helpers;

namespace Swampy.IntegrationTest.Controllers
{
    [TestFixture]
    public class ConfigurationItemControllerTest : AbstractControllerTest
    {
        [SetUp]
        public void Setup()
        {
            MappingConfig.Configure();
        }

        public ConfigurationItemControllerTest() : base(TheDatabase.MustBeFresh)
        {
            
        }

        [Test]
        public void calculateactualvalue_checks_contents_and_hydrates_object()
        {
            var environment = new SwampyEnvironment("name", "domain");            
            var tokenizedItem = new ConfigurationItem("blogs", "one", ConfigurationItemType.Simple, environment) { StoreAsToken = true};

            environment.ConfigurationItems.Add(tokenizedItem);

            object id = null;

            SetupData(x => id = x.Save(environment));

            var input = new ConfigurationItemInputModel()
                {
                    EnvironmentId = (int) id,
                    Name = "go",
                    SelectedItemType = ConfigurationItemType.Simple,
                    Value = "{blogs} two"
                };

            JsonResult result = null;

            ExecuteAction<ConfigurationItemController>(controller => result = controller.CalculateActualValue(input) as JsonResult);

            Assert.AreEqual("one two", result.Data);

        }
    }
}
