using FluentNHibernate.Mapping;
using Swampy.Business.DomainModel.Entities;
using Swampy.Business.DomainModel.ValueObjects;

namespace Swampy.Business.Infrastructure.NHibernate.Mappings
{

    public class ConfigurationItemMap : ClassMap<ConfigurationItem>
    {
        public ConfigurationItemMap()
        {
            Id(x => x.Id);
            References(x => x.SwampyEnvironment).Cascade.All().UniqueKey("UQ_ConfigurationItem_EnvironmentId_Name");
            Map(x => x.Name).UniqueKey("UQ_ConfigurationItem_EnvironmentId_Name");
            Map(x => x.Value);
            Map(x => x.ConfigurationType);
            Map(x => x.StoreAsToken);

            Component(x => x.ModificationDetails, a =>
            {
                a.Map(x => x.TimeStamp, "ModifiedOn");
                a.Map(x => x.UserName, "ModifiedBy");
            });
        }
    }

}
