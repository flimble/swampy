using FluentNHibernate.Mapping;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Business.Infrastructure.NHibernate.Mappings
{

    public class ConfigurationItemMap : ClassMap<ConfigurationItem>
    {
        public ConfigurationItemMap()
        {
            Table("ConfigurationItem");
            Id(x => x.Id).Column("ConfigurationItemId").GeneratedBy.Native();
            References(x => x.Environment).Column("EnvironmentId").Cascade.All();
            Map(x => x.Key).Column("Name");
            Map(x => x.Value).Column("Value");
            Map(x => x.Type).Column("Type");
        }
    }

}