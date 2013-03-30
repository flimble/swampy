using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Swampy.Business.Infrastructure.NHibernate
{
    public class OneToManyForeignKeyConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Key.ForeignKey(string.Format("FK_{0}_{1}",
                                                  instance.Relationship.Class.Name,
                                                  instance.EntityType.Name));

            instance.Key.Column(string.Format("{0}Id", instance.Relationship.Class.Name));

        }
    }
}
