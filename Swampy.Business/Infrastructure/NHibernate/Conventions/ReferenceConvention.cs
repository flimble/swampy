using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Swampy.Business.Infrastructure.NHibernate
{
    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.ForeignKey(string.Format("FK_{0}_{1}",
                                              instance.EntityType.Name,
                                              instance.Name));

            instance.Column(string.Format("{0}Id", instance.EntityType.Name));
            

        }
    }
}
