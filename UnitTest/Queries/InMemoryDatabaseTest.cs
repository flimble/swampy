﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using Swampy.Business.Infrastructure.NHibernate;
using Swampy.Domain.Entities;
using Swampy.Domain.Entities.Endpoint;

namespace Swampy.UnitTest.Queries
{
    public class InMemoryDatabaseTest : IDisposable
    {
        private static Configuration Configuration;
        public static ISessionFactory SessionFactory;
        protected ISession session;

        public InMemoryDatabaseTest()
        {
            if (Configuration == null)
            {
                var sqLiteConfiguration = SQLiteConfiguration
                    .Standard
                    .InMemory()
                    .ShowSql();

                var sqlServerConfiguration = MsSqlConfiguration.MsSql2008
                                                               .ConnectionString(
                                                                   x =>
                                                                   x.Server("(local)")
                                                                    .TrustedConnection()
                                                                    .Database("Swampy"))
                                                               .ShowSql();

                SessionFactory = NHibernateConfigurationFactory.Configuration(sqLiteConfiguration)             
                    .ExposeConfiguration(cfg => Configuration = cfg)
                    .ExposeConfiguration(x=>x.SetProperty(NHibernate.Cfg.Environment.ReleaseConnections, "on_close"))
                    .BuildSessionFactory();

                
            }

            session = SessionFactory.OpenSession();

            new SchemaExport(Configuration).Execute(true, true, false, session.Connection, Console.Out);
        }

        public void Dispose()
        {
            session.Dispose();
        }
    }
}
