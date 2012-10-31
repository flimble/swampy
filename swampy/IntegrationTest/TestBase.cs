using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Raven.Client;

namespace Swampy.IntegrationTest.Mongo
{
    public abstract class TestBase
    {
        //private string _testdbname = "swampyintegrationtests";
        protected IDocumentSession Session;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {

        }

        [SetUp]
        public void Setup()
        {
            //Session = new Session("mongodb://localhost/?safe=true", _testdbname);
            //MongoConfiguration.Configure();
            /*try
            {
                Session.Server.DropDatabase(_testdbname);

            }
            catch { }*/
        }

        [TearDown]
        public void TearDown()
        {
            /*Session.Server.DropDatabase(_testdbname);
            Session.Dispose();*/
        }
    }
}
