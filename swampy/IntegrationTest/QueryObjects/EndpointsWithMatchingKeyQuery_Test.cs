using System.Collections.Generic;
using NUnit.Framework;
using Swampy.IntegrationTest.Mongo;

namespace Swampy.IntegrationTest.QueryObjects
{
    [TestFixture]
    public class EndpointsWithMatchingKeyQuery_Test : TestBase
    {
        [Test]
        public void returns_single_key_with_connection_string()
        {
            TestDatabase.Up();

            /*var query = new EndpointsWithMatchingKeyQuery
                            {
                                EnvironmentName = "SIT1",
                                Keys = new List<string>(new[] { "CommonDBConnectionString" })
                            };
            */
            Assert.Inconclusive("To complete. Issue with querying nested collections with the IMongoQuery interface. Go figure.");

            //var results = Session.Query(query);

            //Assert.AreEqual(1, results.Count());




        }
    }
}
