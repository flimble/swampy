﻿using System.Web.Mvc;
using NUnit.Framework;
using Swampy.Admin.Web.Controllers;
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
        public void detail_returns_view_with_data_populated()
        {
            //arrange
            var config = new SwampyEnvironment("TEST1", "domain.com");
            SetupData(session => session.Save(config));

            ViewResult result = null;
            
            //act
            ExecuteAction<EnvironmentController>(controller => result = controller.Detail("TEST1") as ViewResult);

            //assert
            var data = result.Model as EnvironmentReadModel;
            Assert.IsNotNull(data);
            Assert.AreEqual("TEST1", data.environmentName);
        }
    }
}
