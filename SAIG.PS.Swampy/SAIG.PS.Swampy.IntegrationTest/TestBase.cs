using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAIG.PS.Swampy.MongoDataAccess;
using SAIG.PS.Swampy.Service;

namespace SAIG.PS.Swampy.IntegrationTest.Mongo
{
    public abstract class TestBase
    {
        private string _testdbname = "swampyintegrationtests";
        protected Session Session;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {

        }

        [SetUp]
        public void Setup()
        {
            Session = new Session("mongodb://localhost/?safe=true", _testdbname);
            MongoConfiguration.Configure();
            try
            {
                Session.Server.DropDatabase(_testdbname);

            }
            catch { }
        }

        [TearDown]
        public void TearDown()
        {
            //Session.Server.DropDatabase(_testdbname);
            Session.Dispose();
        }
    }
}
