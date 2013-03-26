using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Swampy.Business.Infrastructure.NHibernate
{
    public class FullIdNameConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(instance.EntityType.Name + "Id");
            instance.GeneratedBy.Native();
        }
    }
}