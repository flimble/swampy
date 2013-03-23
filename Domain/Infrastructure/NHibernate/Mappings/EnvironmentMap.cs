
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Swampy.Business.DomainModel.Entities;
using Swampy.Domain.Entities;

namespace Swampy.Domain.Infrastructure.Mappings
{
    public class EnvironmentMap : ClassMap<Environment>
    {
        public EnvironmentMap()
        {
            Table("Environment");
            Id(x => x.Id).Column("EnvironmentId").GeneratedBy.Native();
            Map(x => x.Name).Column("Name").Unique();
            References(x => x.Domain).Cascade.All();
            HasMany(x => x.SimpleEndpoints).Cascade.All();
            HasMany(x => x.Servers).Cascade.All();
        }
    }

}