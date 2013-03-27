﻿
using System;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Swampy.Business.Infrastructure.NHibernate;

namespace Swampy.UnitTest.Queries
{
    public class AbstractInMemoryDatabaseTest : IDisposable
    {
        private readonly bool _cleanBetweenTests;
        private static Configuration Configuration;
        public static ISessionFactory SessionFactory;
        protected ISession session;

        public AbstractInMemoryDatabaseTest() : this(true) { }

        public AbstractInMemoryDatabaseTest(bool cleanBetweenTests)
        {
            _cleanBetweenTests = cleanBetweenTests;
            if (Configuration == null)
            {
                var sqLiteConfiguration = SQLiteConfiguration
                    .Standard
                    .InMemory()
                    .ShowSql();

                SessionFactory = NHibernateConfigurationFactory.Configuration(sqLiteConfiguration)
                    .ExposeConfiguration(cfg => Configuration = cfg)
                    .ExposeConfiguration(x => x.SetProperty(NHibernate.Cfg.Environment.ReleaseConnections, "on_close"))
                    .BuildSessionFactory();


            }

            if(!_cleanBetweenTests)
                CreateNewSession();
        }

        private void CreateNewSession()
        {
            session = SessionFactory.OpenSession();

            new SchemaExport(Configuration).Execute(true, true, false, session.Connection, Console.Out);
        }

        public void Dispose()
        {
            session.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            if (_cleanBetweenTests)
                CreateNewSession();
        }

        [TearDown]
        public void TearDown()
        {
            if (_cleanBetweenTests)
                Dispose();
        }
    }
}
