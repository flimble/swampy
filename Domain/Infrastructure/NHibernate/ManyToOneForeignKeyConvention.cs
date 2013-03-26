﻿using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Swampy.Business.Infrastructure.NHibernate
{
    public class ManyToOneForeignKeyConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.ForeignKey(string.Format("FK_{0}_{1}",
                                              instance.EntityType.Name,
                                              instance.Name));
        }
    }
}