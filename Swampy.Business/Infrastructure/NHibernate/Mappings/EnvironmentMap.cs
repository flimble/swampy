using FluentNHibernate.Mapping;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Business.Infrastructure.NHibernate.Mappings
{
    public class EnvironmentMap : ClassMap<SwampyEnvironment>
    {
        public EnvironmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Unique();
            Map(x => x.Domain);
            Map(x => x.Description).Nullable();
            HasMany(x => x.ConfigurationItems).Cascade.All();
            HasMany(x => x.Servers).Cascade.All();

            Component(x => x.ModificationDetails, a =>
            {
                a.Map(x => x.TimeStamp, "ModifiedOn");
                a.Map(x => x.UserName, "ModifiedBy");
            });
        }
    }

}
