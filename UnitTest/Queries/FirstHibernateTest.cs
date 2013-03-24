using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Swampy.Business.DomainModel.Entities;
using Swampy.Domain;
using Swampy.Domain.Entities;
using Swampy.Domain.Entities.Endpoint;

namespace Swampy.UnitTest.Queries
{
    [TestFixture]
    public class FirstHibernateTest : InMemoryDatabaseTest
    {

        public FirstHibernateTest() : base(true) {}
        

        [Test]
        public void Can_load_and_save_environment()
        {
            object id;
            
            using (var tx = session.BeginTransaction())
            {
                var e = new Environment("SIT1","saig.frd.global");
                                
                e.SimpleEndpoints.Add(new ConfigurationItem("anEndpoint", "abc", ConfigurationItemType.Simple, e));

                e.AddServer("ssrdbserver","ausydhq-pstsq04");

                id = session.Save(e);
                tx.Commit();
            }

            session.Clear();

            using (var tx = session.BeginTransaction())
            {
                var environment = session.Load<Environment>(id);

                Assert.AreEqual("SIT1",environment.Name);
                Assert.AreEqual("saig.frd.global", environment.Domain.Name);
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
                var e = new Environment("SIT1", "saig.frd.global");

                e.SimpleEndpoints.Add(new ConfigurationItem("anEndpoint", "abc", ConfigurationItemType.Simple, e));

                e.AddServer("ssrdbserver", "ausydhq-pstsq04");

                id = session.Save(e);
                tx.Commit();
            }

            session.Clear();

            using (var tx = session.BeginTransaction())
            {
                var environment = session.Load<Environment>(id);

                Assert.AreEqual("SIT1", environment.Name);
                Assert.AreEqual("saig.frd.global", environment.Domain.Name);
                Assert.IsTrue(environment.Servers.Count == 1);

                tx.Commit();
            }

        }
    }
}
