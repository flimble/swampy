using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Swampy.Domain.Entities.Endpoint;

namespace Swampy.Business.DomainModel.Mappings
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
