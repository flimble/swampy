using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Swampy.Admin.Web.Models;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.UnitTest.Tests.Admin.MVC.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Some duplicated testing here with custom validators - but needed for the conditional validation</remarks>
    [TestFixture]
    public class ConfigurationItemInputValidationTest
    {
        private ConfigurationItemInputValidator _validator ;

        [SetUp]
        public void Setup()
        {
            _validator = new ConfigurationItemInputValidator();
        }

        [Test]
        [TestCase(ConfigurationItemType.DatabaseConnectionString,"jf")]
        [TestCase(ConfigurationItemType.Simple, "")]
        [TestCase(ConfigurationItemType.ServerUrl, "www test:com")]
        public void invalid_configurationvalues_generate_error(ConfigurationItemType type, string value)
        {
            var underTest = new ConfigurationItemInputModel
                {
                    Id = null,
                    SelectedItemType = type,
                    Value = value
                };

            _validator.ShouldHaveValidationErrorFor(x => x.Value, underTest);

        }

        [Test]
        public void empty_configuration_item_has_errors()
        {
            var underTest = new ConfigurationItemInputModel();

            _validator.ShouldHaveValidationErrorFor(x => x.Name, underTest);

        }

        [Test]
        [TestCase(ConfigurationItemType.DatabaseConnectionString, @"Data Source=(local);initial catalog=myDB;Trusted_Connection=True;persist security info=False;packet size=4096")]
        [TestCase(ConfigurationItemType.Simple, "validString")]
        [TestCase(ConfigurationItemType.ServerUrl, "www.google.com")]
        public void valid_configurationvalues_do_not_generate_error(ConfigurationItemType type, string value)
        {
            var underTest = new ConfigurationItemInputModel
            {
                Id = null,
                SelectedItemType = type,
                Value = value
            };

            _validator.ShouldNotHaveValidationErrorFor(x => x.Value, underTest);

        }
    }
}
