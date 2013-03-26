using FluentNHibernate.Mapping;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Business.Infrastructure.NHibernate.Mappings
{
    public class ServerMap : ClassMap<SwampyServer>
    {
        public ServerMap()
        {
            Id(x => x.Id);
            References(x => x.SwampyEnvironment);
            Map(x => x.Name);
            //References(x => x.Domain);

            //References(x => x.Domain).Column("DomainId").Cascade.All();

        }
    }
}
