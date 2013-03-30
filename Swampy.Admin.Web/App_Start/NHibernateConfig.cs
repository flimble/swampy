using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Swampy.Business.Infrastructure.NHibernate;

namespace Swampy.Admin.Web.App_Start
{
    public class NHibernateConfig
    {
        public static ISessionFactory SessionFactory;

        private static ISessionFactory BuildSessionFactory()
        {
            var sqlServerConfiguration = MsSqlConfiguration.MsSql2008
                                                              .ConnectionString(
                                                                  x =>
                                                                  x.Server("(local)")
                                                                   .TrustedConnection()
                                                                   .Database("Swampy"))
                                                              .ShowSql();


            return NHibernateConfigurationFactory.Configuration(sqlServerConfiguration)
                .BuildConfiguration()
                .BuildSessionFactory();
        }

        public static void Configure()
        {
            SessionFactory = BuildSessionFactory();
        }
    }
}
