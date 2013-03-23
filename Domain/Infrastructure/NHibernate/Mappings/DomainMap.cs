using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Swampy.Domain.Entities;

namespace Swampy.Domain.DomainModel.Mappings
{
    public class DomainMap : ClassMap<Business.DomainModel.ValueObjects.Domain>
    {
        public DomainMap()
        {
            Table("Domain");
            Id(x => x.Id).Column("DomainId").GeneratedBy.Native();
            Map(x => x.Name).Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore).Unique();
        }
    }
}
