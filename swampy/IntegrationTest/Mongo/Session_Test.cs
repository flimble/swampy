using System;
using System.Linq;
using NUnit.Framework;
using Swampy.MongoDataAccess;
using Swampy.Service;
using Swampy.Service.Entities.Endpoint;
using Environment = Swampy.Service.Entities.Environment;

namespace Swampy.IntegrationTest.Mongo
{
    [TestFixture]
    public class Session_Test : TestBase
    {


        [Test]
        public void insert_environment_test()
        {
            

                var e = new Environment();
                e.Name = "SIT1";
                e.Endpoints.Add(new DatabaseConnectionString { Key="adbconnectionstring", Value = "ABV" });
                e.Endpoints.Add(new WebpageUrl { Key="awebpageurl", Value = "def" });

                Session.Save(e);

                var results = Session.All<Environment>();

                Assert.AreEqual(1, results.Count());
                Assert.AreEqual(2, results.First().Endpoints.Count);                      
        }


        [Test]
        public void query_test_single_level()
        {
            

            var sit1 = new Environment();
            sit1.Name = "SIT1";
            sit1.Endpoints.Add(new DatabaseConnectionString { Key = "adbconnectionstring", Value = "ABV" });
            sit1.Endpoints.Add(new WebpageUrl { Key = "awebpageurl", Value = "def" });
            Session.Save(sit1);

            var sit2 = new Environment();
            sit2.Name = "SIT2";
            sit2.Endpoints.Add(new DatabaseConnectionString { Key = "adbconnectionstring", Value = "deh" });
            Session.Save(sit2);


            var results = from e in Session.All<Environment>()
                          where e.Name == "SIT1"
                          select e;

            Assert.AreEqual(1, results.Count());
            Assert.AreEqual(2, results.First().Endpoints.Count);
            Assert.IsInstanceOf<DatabaseConnectionString>(results.First().Endpoints[0]);
        }

        [Test]
        public void query_test_nested()
        {

            var sit1 = new Environment();
            sit1.Name = "SIT1";
            sit1.Endpoints.Add(new DatabaseConnectionString { Key = "adbconnectionstring", Value = "ABV" });
            sit1.Endpoints.Add(new WebpageUrl { Key = "awebpageurl", Value = "def" });
            Session.Save(sit1);

            var sit2 = new Environment();
            sit2.Name = "SIT2";
            sit2.Endpoints.Add(new DatabaseConnectionString { Key = "adbconnectionstring", Value = "deh" });
            Session.Save(sit2);


            var results = Session.All<Environment>().ToList()
                .SelectMany(x => x.Endpoints)
                .Where(x => x.Value == "deh");

                                                

            Assert.AreEqual(1, results.Count());
            Assert.IsInstanceOf<DatabaseConnectionString>(results.First());
            Assert.AreEqual("deh", results.First().Value);

        }

        [Test]
        public void update_existing_test()
        {

            var sit1 = new Environment();
            sit1.Name = "SIT1";
            sit1.Endpoints.Add(new DatabaseConnectionString { Key = "adbconnectionstring", Value = "ABV" });
            sit1.Endpoints.Add(new WebpageUrl { Key = "awebpageurl", Value = "def" });
            Session.Save(sit1);


            var existing = Session.All<Environment>().First(x => x.Name == "SIT1");

            foreach(var endpoint in existing.Endpoints)
            {
                endpoint.Value = "zubbie";
            }


            Session.Save(existing);
           
        }

        
    }
}
