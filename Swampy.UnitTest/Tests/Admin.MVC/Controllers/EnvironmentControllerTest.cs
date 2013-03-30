using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using NHibernate.Util;
using NUnit.Framework;
using Swampy.Admin.Web.Controllers;
using Swampy.Admin.Web.Models.Operation;
using Swampy.Admin.Web.Models.ReadModels;
using Swampy.Business.DomainModel.Entities;
using Swampy.Business.Infrastructure.Abstractions;
using Swampy.UnitTest.Admin.MVC.Controllers;

namespace Swampy.UnitTest.Tests.Admin.MVC.Controllers
{
    [TestFixture]
    public class EnvironmentControllerTest : AbstractControllerTest
    {

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
            Assert.IsInstanceOf<EnvironmentOutput>(result.Model);

            var data = (EnvironmentOutput)result.Model;            
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
            Assert.IsInstanceOf<EnvironmentInput>(result.Model);
        }

        [Test]
        [TestCase("TEST1", "domain.com")]
        public void edit_with_valid_object_(string environmentName, string domain)
        {
            //arrange
            var config = new EnvironmentInput();
            config.Name = environmentName;
            config.Domain = domain;

            RedirectToRouteResult result = null;

            //act
            ExecuteAction<EnvironmentController>(controller => result = controller.Edit(config) as RedirectToRouteResult);

            //assert    
            Assert.AreEqual("Index", result.RouteValues["action"]);

            session.Query<SwampyEnvironment>()
                .Any(x=>x.Name == environmentName);
           
                
        }
    }
}
