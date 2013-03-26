using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.UnitTest.Tests.Domain
{
    [TestFixture]
    public class ConfigurationItemTest
    {
        [Test]
        public void HydrateItems_replaces_tokens_with_real_data()
        {
            var e = new SwampyEnvironment("SIT1", "ausydhc-pspsq10");
            var item1 = new ConfigurationItem("key1", "d", ConfigurationItemType.Simple, e);
            var item2 = new ConfigurationItem("key2", "{key3}a", ConfigurationItemType.Simple, e);            
            var item3 = new ConfigurationItem("key3", "c", ConfigurationItemType.Simple, e) { StoreAsToken = true};
            var item4 = new ConfigurationItem("key4", "b", ConfigurationItemType.Simple, e);

            e.ConfigurationItems = new List<ConfigurationItem> { item1, item2, item3, item4};
            
            Assert.AreEqual("{key3}a",e.ConfigurationItems.Single(x=>x.Key == "key2").Value);

            var resolvedItems = e.HydrateItems();
            
            Assert.AreEqual("ca", resolvedItems.Single(x => x.Key == "key2").HydratedValue);

        }


    }
}
