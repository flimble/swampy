using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using NUnit.Framework;
using SAIG.PS.Swampy.IntegrationTest.Mongo;
using SAIG.PS.Swampy.Service;
using SAIG.PS.Swampy.Service.Endpoint;

namespace SAIG.PS.Swampy.UnitTest.Mongo
{
    [TestFixture]
    public class MongoSpike
    {
        [Test]
        public void Do()
        {
            MongoConfiguration.Configure();
            var database = MongoConfiguration.TestDatabase;
            
            database.DropCollection("Environments");

            var collection = database.GetCollection<SystemEnvironment>("Environments");

            var e = new SystemEnvironment();
            e.Name = "SIT1";
            e.Endpoints.Add(new DatabaseConnectionString { Value = "ABV" });
            e.Endpoints.Add(new WebpageUrl { Value = "def" });            

            collection.Insert(e);


            var results = collection.FindAllAs<SystemEnvironment>();

   

            Assert.AreEqual(1, results.Count());
            Assert.AreEqual(2, results.First().Endpoints.Count);

        }

        protected void CreateEnvironmentData()
        {
            var environment = new SystemEnvironment("SIT1");

            environment.Endpoints.Add(new DatabaseConnectionString
                                          {
                                              Key="CommonDBConnectionString",
                                              Value=@"data source=AUSYDHQ-PSTSQ04.SAIG.frd.global;initial catalog=Common;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                          });
            environment.Endpoints.Add(new DatabaseConnectionString
                                          {
                                              Key = "SSRDBConnectionString",
                                              Value = @"data source=AUSYDHQ-PSTSQ04.SAIG.frd.global;initial catalog=SSR;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                          });
            environment.Endpoints.Add(new DatabaseConnectionString
                                          {
                                              Key = "WorkflowDBConnectionString",
                                              Value = @"data source=AUSYDHQ-PSTSQ03.SAIG.frd.global;initial catalog=WorkflowStore;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"   
                                          });
            environment.Endpoints.Add(new DatabaseConnectionString
                                          {
                                              Key = "FilestoreDBConnectionString",
                                              Value = @"data source=AUSYDHQ-PSTSQ03.SAIG.frd.global;initial catalog=Filestore;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                          });
        }
    }
}
