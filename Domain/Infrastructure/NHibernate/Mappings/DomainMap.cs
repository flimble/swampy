using FluentNHibernate.Mapping;

namespace Swampy.Business.Infrastructure.NHibernate.Mappings
{
    public class DomainMap : ClassMap<Business.DomainModel.ValueObjects.Domain>
    {
        public DomainMap()
        {
            Table("Domain");
            Id(x => x.Id).Column("DomainId").GeneratedBy.Native();
            Map(x => x.Name).Unique();
        }
    }
}
