using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAIG.PS.Swampy.Service;
using SAIG.PS.Swampy.Service.DomainServices;

namespace SAIG.PS.Swampy.IntegrationTest.Mongo
{
    [TestFixture]
    public class SwampyEndpointService_Test
    {
        [SetUp]
        public void Setup()
        {
            Database.Down();
        }


        [Test]
        public void single_endpoint_returns_saved_value_to_service()
        {
            Database.Up();

            var underTest = new SwampyEndpointService(Database.TestSession());

            var result = underTest.GetSingleEndpoint("SIT1", "CommonDBConnectionString", "testApp");

            Assert.AreEqual("data source=AUSYDHQ-PSTSQ04.SAIG.frd.global;initial catalog=Common;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096", result.Value);

            Database.Down();
        }


        [Test]
        public void multiple_endpoint_returns_saved_value_to_service()
        {
            Database.Up();

            var underTest = new SwampyEndpointService(Database.TestSession());

            var result = underTest.GetEndpoints("SIT1", new [] {"CommonDBConnectionString"} , "testApp");

            Assert.AreEqual("data source=AUSYDHQ-PSTSQ04.SAIG.frd.global;initial catalog=Common;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096", result[0].Value);

            Database.Down();
        }

        [Test]
        public void incorrect_key_returns_empty_result_list()
        {
            Database.Up();

            var underTest = new SwampyEndpointService(Database.TestSession());

            var result = underTest.GetEndpoints("SIT1", new[] { "ZZooASASDFASD" }, "testApp");

            Assert.AreEqual(0, result.Count());

            Database.Down();
        }

        [Test]
        
        public void incorrect_environment_name_returns_empty_result_list()
        {
            Assert.Inconclusive("TODO");

            Database.Up();

            var underTest = new SwampyEndpointService(Database.TestSession());

            var result = underTest.GetEndpoints("SITXXX", new[] { "CommonDBConnectionString" }, "testApp");

            Assert.AreEqual(0, result.Count());

            Database.Down();
        }
    }
}
