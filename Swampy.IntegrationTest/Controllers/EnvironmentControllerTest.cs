using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using NUnit.Framework;
using Swampy.Admin.Web.App_Start;
using Swampy.Admin.Web.Controllers;
using Swampy.Admin.Web.Models;
using Swampy.Admin.Web.Models.Operation;
using Swampy.Business.DomainModel.Entities;
using Swampy.UnitTest.Admin.MVC.Controllers;
using Swampy.UnitTest.Helpers;
using EnvironmentReadModel = Swampy.Admin.Web.Models.Operation.EnvironmentReadModel;

namespace Swampy.UnitTest.Tests.Admin.MVC.Controllers
{
    [TestFixture]
    public class EnvironmentControllerTest : AbstractControllerTest
    {
        public EnvironmentControllerTest() : base(TheDatabase.MustBeFresh)
        {
            
        }

        [SetUp]
        public void Setup()
        {
            MappingConfig.Configure();
        }


        [Test]
        [TestCase("TEST1", "domain.com")]
        public void detail_returns_view_with_data_populated(string environmentName, string domain)
        {

            //arrange
            var config = new SwampyEnvironment(environmentName, domain);

            SetupData(session => session.Save(config));

            ViewResult result = null;

            //act
            ExecuteAction<EnvironmentController>(controller => result = controller.Detail(environmentName) as ViewResult);

            //assert
            Assert.IsInstanceOf<EnvironmentReadModel>(result.Model);

            var data = (EnvironmentReadModel)result.Model;
            Assert.IsNotNull(data);
            Assert.AreEqual(environmentName, data.Name);
        }

        [Test]
        [TestCase("TEST1", "domain.com")]
        public void edit_with_id_returns_mapped_view_with_environmentinput(string environmentName, string domain)
        {
            //arrange
            var config = new SwampyEnvironment(environmentName, domain);
            object id = null;
            SetupData(session => id = session.Save(config));

            ViewResult result = null;

            //act
            ExecuteAction<EnvironmentController>(controller => result = controller.Edit((int)id) as ViewResult);

            //assert    
            Assert.IsInstanceOf<EnvironmentInputModel>(result.Model);
        }

        [Test]
        [TestCase("TEST1", "domain.com")]
        public void edit_with_valid_object_persists_nested_object_graph(string environmentName, string domain)
        {
            //arrange
            var config = new EnvironmentInputModel();
            config.Name = environmentName;
            config.Domain = domain;
            config.ConfigurationItems.Add(new ConfigurationItemInputModel{Name = "Joe", SelectedItemType = ConfigurationItemType.Simple, Value="aValue"});

            RedirectToRouteResult result = null;

            //act
            ExecuteAction<EnvironmentController>(controller => result = controller.Edit(config) as RedirectToRouteResult);

            //assert    
            Assert.AreEqual("Index", result.RouteValues["action"]);

            var environment = Session.Query<SwampyEnvironment>().Single(x => x.Name == environmentName);
            Assert.AreEqual(1, environment.ConfigurationItems.Count);
            Assert.AreEqual("Joe", environment.ConfigurationItems.First().Name);

     
        }

        [Test]
        [TestCase("TEST1", "domain.com")]
        public void addconfigurationitem_redirects_to_detail_screen(string environmentName, string domain)
        {
            //arrange
            var config = new SwampyEnvironment(environmentName, domain);
            object id = null;
            SetupData(session => id = session.Save(config));

            
            var item = new ConfigurationItemInputModel {Name = "Joe", SelectedItemType = ConfigurationItemType.Simple, Value = "aValue", EnvironmentId = (int)id};
            RedirectToRouteResult result = null;

            //act
            ExecuteAction<EnvironmentController>(controller => result = controller.AddConfigurationItem(item) as RedirectToRouteResult);

            //assert    
            Assert.AreEqual("Detail", result.RouteValues["action"]);                    

        }
    }
}
