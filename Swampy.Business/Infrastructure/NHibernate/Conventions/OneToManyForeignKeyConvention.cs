using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Swampy.Business.Infrastructure.NHibernate
{
    public class OneToManyForeignKeyConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance target)
        {
            target.Key.ForeignKey(string.Format("FK_{0}_{1}",
                                                target.Relationship.Class.Name,
                                                target.EntityType.Name));
          
            target.Not.KeyNullable();

            target.Key.Column(string.Format("{0}Id", target.EntityType.Name));

        }
    }
}
