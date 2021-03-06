using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Swampy.Business.DomainModel.Entities.Interfaces;
using Swampy.Business.DomainModel.ValueObjects;

namespace Swampy.Business.DomainModel.Entities
{
    public class SwampyEnvironment : AbstractEntity
    {
        public virtual string Name { get; set; }

        private ITokenBuilder _builder;

        public SwampyEnvironment(string name)
            : this()
        {
            Name = name;
            this._builder = new TokenBuilder();
        }

        public SwampyEnvironment(string name, string domain)
            : this()
        {
            this.Name = name;
            this.Domain = domain;
        }

        public virtual string Domain { get; set; }

        public virtual string Description { get; set; }

        protected SwampyEnvironment()
        {
            ConfigurationItems = new List<ConfigurationItem>();
                       
        }

        public virtual SwampyEnvironment Clone()
        {
            var result = Mapper.Map<SwampyEnvironment, SwampyEnvironment>(this);

            return result;
        }

        public virtual IList<ConfigurationItem> ConfigurationItemsUsedByOthers
        {
            get { return this.ConfigurationItems.Where(x => x.StoreAsToken).ToList(); }
        }

        public virtual IList<ConfigurationItem>  HydrateItems()
        {

            var orderedByDependency = this.ConfigurationItems
                                          .OrderByDescending(x => x.StoreAsToken)
                                          .ToList();

            foreach (var item in orderedByDependency)
            {
                if (item.ContainsTokens())
                {
                    item.Hydrate(this.ConfigurationItemsUsedByOthers);
                }                
            }

            return orderedByDependency;
        }


        public virtual string Fake { get; set; }

        public virtual IList<ConfigurationItem> ConfigurationItems { get; set; }


       

    }
}
