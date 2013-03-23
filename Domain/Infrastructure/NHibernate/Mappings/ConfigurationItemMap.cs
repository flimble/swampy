using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Swampy.Domain.Entities.Endpoint;

namespace Swampy.Domain.Infrastructure.Mappings
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