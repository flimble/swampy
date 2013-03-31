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

            Component(x => x.ModificationDetails, a =>
            {
                a.Map(x => x.TimeStamp, "ModifiedOn");
                a.Map(x => x.UserName, "ModifiedBy");
            });

        }
    }
}
