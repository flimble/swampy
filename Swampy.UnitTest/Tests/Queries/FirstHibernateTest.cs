using NUnit.Framework;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.UnitTest.Queries
{
    [TestFixture]
    public class FirstHibernateTest : AbstractNHibernateDatabaseTest
    {

        public FirstHibernateTest() : base(true) {}
        

        [Test]
        public void Can_load_and_save_environment()
        {
            object id;
            
            using (var tx = session.BeginTransaction())
            {
                var e = new SwampyEnvironment("SIT1","saig.frd.global");
                                
                e.ConfigurationItems.Add(new ConfigurationItem("anEndpoint", "abc", ConfigurationItemType.Simple, e));

                e.AddServer("ssrdbserver","ausydhq-pstsq04");

                id = session.Save(e);
                tx.Commit();
            }

            session.Clear();

            using (var tx = session.BeginTransaction())
            {
                var environment = session.Load<SwampyEnvironment>(id);

                Assert.AreEqual("SIT1",environment.Name);
                Assert.AreEqual("saig.frd.global", environment.Domain);
                Assert.IsTrue(environment.Servers.Count == 1);

                tx.Commit();
            }

        }

        [Test]
        public void load_another_test()
        {
            object id;

            using (var tx = session.BeginTransaction())
            {
                var e = new SwampyEnvironment("SIT1", "saig.frd.global");

                e.ConfigurationItems.Add(new ConfigurationItem("anEndpoint", "abc", ConfigurationItemType.Simple, e));

                e.AddServer("ssrdbserver", "ausydhq-pstsq04");

                id = session.Save(e);
                tx.Commit();
            }

            session.Clear();

            using (var tx = session.BeginTransaction())
            {
                var environment = session.Load<SwampyEnvironment>(id);

                Assert.AreEqual("SIT1", environment.Name);
                Assert.AreEqual("saig.frd.global", environment.Domain);
                Assert.IsTrue(environment.Servers.Count == 1);

                tx.Commit();
            }

        }
    }
}
