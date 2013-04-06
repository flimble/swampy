using AutoMapper;
using NUnit.Framework;
using Swampy.Admin.Web.Models;
using Swampy.Admin.Web.Models.Mappers;
using Swampy.Admin.Web.Models.ReadModels;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.UnitTest.Tests.Admin.Web.Models.Mappings
{
    [TestFixture]
    public class ConfigurationItemProfileTest
    {
        [SetUp]
        public void Setup()
        {
            Mapper.Initialize(x=>x.AddProfile<ConfigurationItemProfile>());   
        }

        [Test]
        [TestCase("key","value",ConfigurationItemType.Simple, "environment")]
        public void assert_all_required_properties_are_mapped_to_viewmodel(string key, string value, ConfigurationItemType type, string environmentname)
        {
            //var configItem = new ConfigurationItem(key, value, type, new SwampyEnvironment(environmentname));

            //var viewModel = Mapper.Map<ConfigurationItem, EnvironmentReadModel>(configItem);


            Assert.Inconclusive("TODO: Complete this test");
        }


        [Test]
        [TestCase("key", "value", ConfigurationItemType.Simple, "environment")]
        public void assert_all_required_properties_are_mapped_to_entity(string name, string value, ConfigurationItemType type, string environmentname)
        {
            var configItem = new ConfigurationItemInputModel
                {
                    Name = name,
                    Value = value,
                    Type = type.ToNullSafeString()
                };

            var viewModel = Mapper.Map<ConfigurationItemInputModel, ConfigurationItem>(configItem);

            Assert.AreEqual(name,viewModel.Name);
            Assert.AreEqual(value, viewModel.Value);
        }

    }
}
