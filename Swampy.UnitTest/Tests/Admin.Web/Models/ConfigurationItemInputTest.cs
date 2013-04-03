using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Swampy.Admin.Web.Models;

namespace Swampy.UnitTest.Tests.Admin.MVC.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Some duplicated testing here with custom validators - but needed for the conditional validation</remarks>
    [TestFixture]
    public class ConfigurationItemInputTest
    {
        private ConfigurationItemInputValidator _validator ;

        [SetUp]
        public void Setup()
        {
            _validator = new ConfigurationItemInputValidator();
        }

        [Test]
        [TestCase("DatabaseConnectionString","jf")]
        [TestCase("Basic", "")]
        [TestCase("Url", "www test:com")]
        public void invalid_configurationvalues_generate_error(string type, string value)
        {
            var underTest = new ConfigurationItemInput
                {
                    Id = null,
                    Type = type,
                    Value = value
                };

            _validator.ShouldHaveValidationErrorFor(x => x.Value, underTest);

        }

        [Test]
        [TestCase("DatabaseConnectionString", @"Data Source=(local);initial catalog=myDB;Trusted_Connection=True;persist security info=False;packet size=4096")]
        [TestCase("Basic", "validString")]
        [TestCase("Url", "www.google.com")]
        public void valid_configurationvalues_do_not_generate_error(string type, string value)
        {
            var underTest = new ConfigurationItemInput
            {
                Id = null,
                Type = type,
                Value = value
            };

            _validator.ShouldNotHaveValidationErrorFor(x => x.Value, underTest);

        }
    }
}
