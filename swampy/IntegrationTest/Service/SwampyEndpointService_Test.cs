using System.Linq;
using NUnit.Framework;
using Swampy.Domain;
using Swampy.Domain.DomainServices;

namespace Swampy.IntegrationTest.Service
{
    [TestFixture]
    public class SwampyEndpointService_Test
    {
        [SetUp]
        public void Setup()
        {
            TestDatabase.Down();

            DataDocumentStore.Initialize();
        }


        [Test]
        public void single_endpoint_returns_saved_value_to_service()
        {
            TestDatabase.Up();

            var underTest = new SwampyEndpointService();

            var result = underTest.GetSingleEndpoint("SIT1", "CommonDBConnectionString", "testApp");

            Assert.AreEqual("data source=AUSYDHQ-PSTSQ04.SAIG.frd.global;initial catalog=Common;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096", result.Value);

            TestDatabase.Down();
        }


        [Test]
        public void multiple_endpoint_returns_saved_value_to_service()
        {
            TestDatabase.Up();

            var underTest = new SwampyEndpointService();

            var result = underTest.GetEndpoints("SIT1", new [] {"CommonDBConnectionString"} , "testApp");

            Assert.AreEqual("data source=AUSYDHQ-PSTSQ04.SAIG.frd.global;initial catalog=Common;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096", result[0].Value);

            TestDatabase.Down();
        }

        [Test]
        public void incorrect_key_returns_empty_result_list()
        {
            TestDatabase.Up();

            var underTest = new SwampyEndpointService();

            var result = underTest.GetEndpoints("SIT1", new[] { "ZZooASASDFASD" }, "testApp");

            Assert.AreEqual(0, result.Count());

            TestDatabase.Down();
        }

        [Test]
        
        public void incorrect_environment_name_returns_empty_result_list()
        {
            Assert.Inconclusive("TODO");

            TestDatabase.Up();

            var underTest = new SwampyEndpointService();

            var result = underTest.GetEndpoints("SITXXX", new[] { "CommonDBConnectionString" }, "testApp");

            Assert.AreEqual(0, result.Count());

            TestDatabase.Down();
        }
    }
}
