﻿using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using Swampy.Business.Infrastructure.NHibernate;

namespace Swampy.Common
{
    public class NHibernateConfig
    {
        public static ISessionFactory SessionFactory;

        private static ISessionFactory BuildSessionFactory()
        {
            var sqlServerConfiguration = MsSqlConfiguration.MsSql2008
                                                              .ConnectionString(
                                                                  x =>
                                                                  x.Server(@".\local")
                                                                   .TrustedConnection()
                                                                   .Database("Swampy"))
                                                              .ShowSql();


            return NHibernateConfigurationFactory.Configuration(sqlServerConfiguration)
                .BuildConfiguration()
                .SetProperty(
                    Environment.SqlExceptionConverter,
                    typeof(MsSqlExceptionConverter).AssemblyQualifiedName)
                .BuildSessionFactory();
        }

        public static void Configure()
        {
            SessionFactory = BuildSessionFactory();
        }
    }
}
