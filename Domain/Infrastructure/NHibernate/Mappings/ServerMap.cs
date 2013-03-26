using FluentNHibernate.Mapping;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Business.Infrastructure.NHibernate.Mappings
{
    public class ServerMap : ClassMap<SwampyServer>
    {
        public ServerMap()
        {
            Table("Server");
            Id(x => x.Id).Column("ServerId").GeneratedBy.Native();
            References(x => x.SwampyEnvironment);
            Map(x => x.Name);
            //References(x => x.Domain);

            //References(x => x.Domain).Column("DomainId").Cascade.All();

        }
    }
}
