using System.Collections.Generic;
using System.Linq;
using Swampy.Business.DomainModel.ValueObjects;

namespace Swampy.Business.DomainModel.Entities
{
    public class SwampyEnvironment : AbstractEntity
    {
        public virtual string Name { get; set; }

        public SwampyEnvironment(string name)
            : this()
        {
            Name = name;
        }

        public SwampyEnvironment(string name, string domain)
            : this()
        {
            this.Name = name;
            this.Domain = domain;
        }

        public virtual string Domain { get; set; }

        protected SwampyEnvironment()
        {
            ConfigurationItems = new List<ConfigurationItem>();
            Servers = new List<SwampyServer>();
        }

        public virtual IList<ConfigurationItem> ConfigurationItemsUsedByOthers
        {
            get { return this.ConfigurationItems.Where(x => x.StoreAsToken).ToList(); }
        }

        public virtual IList<ConfigurationItem>  HydrateItems()
        {
            var builder = new TokenBuilder();

            var orderedByDependency = this.ConfigurationItems
                                          .OrderByDescending(x => x.StoreAsToken)
                                          .ToList();

            foreach (var item in orderedByDependency)
            {
                if (item.ContainsTokens(builder))
                {
                    item.Hydrate(builder, this.ConfigurationItemsUsedByOthers);
                }
            }

            return orderedByDependency;
        }


        public virtual string Fake { get; set; }

        public virtual IList<ConfigurationItem> ConfigurationItems { get; set; }

        public virtual IList<SwampyServer> Servers { get; protected set; }

        public virtual void AddServer(string key, string name)
        {
            Servers.Add(new SwampyServer()
                {
                    Name = name,
                    Key = key,
                    SwampyEnvironment = this
                });

        }

    }
}
