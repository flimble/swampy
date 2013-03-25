using FluentNHibernate.Mapping;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Business.Infrastructure.NHibernate.Mappings
{
    public class ServerMap : ClassMap<Server>
    {
        public ServerMap()
        {
            Table("Server");
            Id(x => x.Id).Column("ServerId").GeneratedBy.Native();
            References(x => x.Environment);
            Map(x => x.Name);
            References(x => x.Domain);

            //References(x => x.Domain).Column("DomainId").Cascade.All();

        }
    }
}
