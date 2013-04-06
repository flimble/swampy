using System;
using NUnit.Framework;
using Swampy.Business.DomainModel.Entities;
using Swampy.Business.Infrastructure.Abstractions;
using Swampy.UnitTest.Helpers;

namespace Swampy.UnitTest.Queries
{
    [TestFixture]
    public class DataAccessTest : AbstractNHibernateDatabaseTest
    {

        public DataAccessTest() : base(TheDatabase.CanBeDirty) { }


        [Test]
        [TestCase("SIT1", "saig.frd.global")]
        public void Can_load_and_save_environment(string environmentName, string domain)
        {
            object id;

            

            using (var tx = Session.BeginTransaction())
            {
                var e = new SwampyEnvironment(environmentName, domain);

                e.ConfigurationItems.Add(new ConfigurationItem("anEndpoint", "abc", ConfigurationItemType.Simple, e));

                e.AddServer("ssrdbserver", "ausydhq-pstsq04");

                id = Session.Save(e);
                tx.Commit();
            }

            Session.Clear();

            using (var tx = Session.BeginTransaction())
            {
                var environment = Session.Load<SwampyEnvironment>(id);

                Assert.AreEqual(environmentName, environment.Name);
                Assert.AreEqual(domain, environment.Domain);
                Assert.IsTrue(environment.Servers.Count == 1);

                tx.Commit();
            }

        }

        [Test]
        [TestCase("SIT2", "saig.frd.global")]
        public void load_another_test(string environmentName, string domain)
        {
            object id;

            using (var tx = Session.BeginTransaction())
            {
                var e = new SwampyEnvironment(environmentName, domain);

                e.ConfigurationItems.Add(new ConfigurationItem("anEndpoint", "abc", ConfigurationItemType.Simple, e));

                e.AddServer("ssrdbserver", "ausydhq-pstsq04");

                id = Session.Save(e);
                tx.Commit();
            }

            Session.Clear();

            using (var tx = Session.BeginTransaction())
            {
                var environment = Session.Load<SwampyEnvironment>(id);

                Assert.AreEqual(environmentName, environment.Name);
                Assert.AreEqual(domain, environment.Domain);
                Assert.IsTrue(environment.Servers.Count == 1);

                tx.Commit();
            }

        }
    }
}
