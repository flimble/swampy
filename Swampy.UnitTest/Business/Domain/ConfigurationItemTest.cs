using System;
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
            
            Assert.AreEqual("{key3}a",e.ConfigurationItems.Single(x=>x.Name == "key2").Value);

            var resolvedItems = e.HydrateItems();
            
            Assert.AreEqual("ca", resolvedItems.Single(x => x.Name == "key2").HydratedValue);

        }

        [Test]
        public void HydrateItems_does_nothing_if_configurationItem_does_not_contain_tokens_for_replacement()
        {
            var c = new ConfigurationItem("key1", "d", ConfigurationItemType.Simple, new SwampyEnvironment("bla", "bla"));
            
            c.Hydrate(new List<ConfigurationItem>());
        
            Assert.AreEqual(c.Value, c.HydratedValue);
        }

        [Test]
        public void HydrateItems_throws_exception_where_config_replacement_requested_but_no_replacementvalue_exists()
        {
            var c = new ConfigurationItem("key1", "d{a}", ConfigurationItemType.Simple, new SwampyEnvironment("bla" ,"bla"));

            

            Assert.Throws<InvalidOperationException>(
                    ()=> c.Hydrate(new List<ConfigurationItem>())                
                );

        }


    }
}
