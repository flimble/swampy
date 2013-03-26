using FluentNHibernate.Mapping;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Business.Infrastructure.NHibernate.Mappings
{

    public class ConfigurationItemMap : ClassMap<ConfigurationItem>
    {
        public ConfigurationItemMap()
        {
            Id(x => x.Id);
            References(x => x.SwampyEnvironment).Cascade.All();
            Map(x => x.Name);
            Map(x => x.Value);
            Map(x => x.ConfigurationType);
            Map(x => x.StoreAsToken);
        }
    }

}