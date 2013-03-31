using FluentNHibernate.Mapping;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Business.Infrastructure.NHibernate.Mappings
{
    public class EnvironmentMap : ClassMap<SwampyEnvironment>
    {
        public EnvironmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Domain);
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
