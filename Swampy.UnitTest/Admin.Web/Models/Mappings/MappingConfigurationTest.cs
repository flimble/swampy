using AutoMapper;
using NUnit.Framework;
using Swampy.Admin.Web.App_Start;

namespace Swampy.UnitTest.Tests.Admin.Web.Models.Mappings
{
    [TestFixture]
    public class MappingConfigurationTest
    {
        [SetUp]
        public void Setup()
        {
            MappingConfig.Configure();
        }

        [Test]
        public void mapping_configuration_maps_target_all_fields()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}
