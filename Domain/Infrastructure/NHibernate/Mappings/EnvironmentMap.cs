using FluentNHibernate.Mapping;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Business.Infrastructure.NHibernate.Mappings
{
    public class EnvironmentMap : ClassMap<SwampyEnvironment>
    {
        public EnvironmentMap()
        {
            Table("Environment");
            Id(x => x.Id).Column("EnvironmentId").GeneratedBy.Native();
            Map(x => x.Name).Column("Name").Unique();
            References(x => x.Domain).Cascade.All();
            HasMany(x => x.ConfigurationItems).Cascade.All();
            HasMany(x => x.Servers).Cascade.All();
        }
    }

}