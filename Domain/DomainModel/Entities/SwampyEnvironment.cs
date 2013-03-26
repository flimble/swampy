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
            Name = name;
            Domain = new Domain(domain);
        }

        public virtual Domain Domain { get; set; }

        protected SwampyEnvironment()
        {
            ConfigurationItems = new List<ConfigurationItem>();
            Servers = new List<SwampyServer>();
        }

        public virtual IList<ConfigurationItem> ConfigurationItemsUsedByOthers
        {
            get { return ConfigurationItems.Where(x => x.StoreAsToken) as IList<ConfigurationItem>; }
        }

        public virtual IList<ConfigurationItem>  ReorderItemsByDependency()
        {
            return null;
        }



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
