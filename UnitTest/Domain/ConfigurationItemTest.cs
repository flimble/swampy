using NUnit.Framework;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.UnitTest.Domain
{
    [TestFixture]
    public class ConfigurationItemTest
    {
        [Test]
        public void test()
        {
            var e = new Environment("SIT1", "ausydhc-pspsq10");
            var underTest = new ConfigurationItem("key", "value", ConfigurationItemType.Simple, e);

            underTest.StoreAsToken
        }
    }
}
