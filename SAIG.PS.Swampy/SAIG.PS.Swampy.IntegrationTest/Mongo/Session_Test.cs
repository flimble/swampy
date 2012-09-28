﻿using System;
using System.Linq;
using NUnit.Framework;
using SAIG.PS.Swampy.MongoDataAccess;
using SAIG.PS.Swampy.Service;
using SAIG.PS.Swampy.Service.Entities.Endpoint;
using Environment = SAIG.PS.Swampy.Service.Entities.Environment;

namespace SAIG.PS.Swampy.IntegrationTest.Mongo
{
    [TestFixture]
    public class Session_Test
    {
        private string _testdbname = "swampyintegrationtests";
        private Session _session;

        [SetUp]
        public void Setup()
        {       
            _session = new Session("mongodb://localhost/?safe=true", _testdbname);
            try
            {
                _session.Server.DropDatabase(_testdbname);
            }
            catch {}            
        }

        [TearDown]
        public void TearDown()
        {
            _session.Server.DropDatabase(_testdbname);
            _session.Dispose();
        }

        [Test]
        public void insert_environment_test()
        {

                var e = new Environment();
                e.Name = "SIT1";
                e.Endpoints.Add(new DatabaseConnectionString { Value = "ABV" });
                e.Endpoints.Add(new WebpageUrl { Value = "def" });

                _session.Save(e);

                var results = _session.All<Environment>();

                Assert.AreEqual(1, results.Count());
                Assert.AreEqual(2, results.First().Endpoints.Count);                      
        }


        [Test]
        public void query_test_single_level()
        {

            var sit1 = new Environment();
            sit1.Name = "SIT1";
            sit1.Endpoints.Add(new DatabaseConnectionString { Value = "ABV" });
            sit1.Endpoints.Add(new WebpageUrl { Value = "def" });
            _session.Save(sit1);

            var sit2 = new Environment();
            sit2.Name = "SIT2";
            sit2.Endpoints.Add(new DatabaseConnectionString { Value = "deh" });
            _session.Save(sit2);


            var results = from e in _session.All<Environment>()
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
            sit1.Endpoints.Add(new DatabaseConnectionString { Value = "ABV" });
            sit1.Endpoints.Add(new WebpageUrl { Value = "def" });
            _session.Save(sit1);

            var sit2 = new Environment();
            sit2.Name = "SIT2";
            sit2.Endpoints.Add(new DatabaseConnectionString { Value = "deh" });
            _session.Save(sit2);


            var results = _session.All<Environment>()
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
            sit1.Endpoints.Add(new DatabaseConnectionString { Value = "ABV" });
            sit1.Endpoints.Add(new WebpageUrl { Value = "def" });
            _session.Save(sit1);


            var existing = _session.All<Environment>().First(x => x.Name == "SIT1");

            foreach(var endpoint in existing.Endpoints)
            {
                endpoint.Value = "zubbie";
            }


            _session.Save(existing);
           
        }

        [Test]
        public void generate_real_values()
        {
            Database.Up();


        }
    }
}
