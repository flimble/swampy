using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Swampy.Business.Infrastructure.NHibernate.Conventions
{
    public class ColumnDefaultNotNullConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Not.Nullable();
        }

    }
}
