﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.Cfg;
using Swampy.Business.Infrastructure.NHibernate.Mappings;

namespace Swampy.Business.Infrastructure.NHibernate
{
    public class NHibernateConfigurationFactory
    {              

        public static FluentConfiguration Configuration(IPersistenceConfigurer databaseConfig)
        {

            return Fluently.Configure()
                           .Database(databaseConfig)
                           .Mappings(cfg => cfg.FluentMappings.AddFromAssembly(typeof (EnvironmentMap).Assembly)
                                               .Conventions.Setup(mappings =>
                                                   {
                                                       mappings.AddAssembly(typeof (EnvironmentMap).Assembly);
                                                       mappings.Add(ForeignKey.EndsWith("Id"));
                                                   }));
        }
     
    }
}
