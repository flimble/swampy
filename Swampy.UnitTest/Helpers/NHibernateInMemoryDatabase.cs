using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Swampy.Business.Infrastructure.NHibernate;

namespace Swampy.UnitTest.Helpers
{
    public class NHibernateInMemoryDatabase : IDisposable
    {
        private static Configuration _configuration;
        private static ISessionFactory _sessionFactory;
        public ISession Session { get; set; }

        public NHibernateInMemoryDatabase()
        {
            _sessionFactory = CreateSessionFactory();            
            BuildSchema();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var dbConfig = SQLiteConfiguration.Standard.InMemory().ShowSql();

            return 
               NHibernateConfigurationFactory.Configuration(dbConfig)
              .ExposeConfiguration(configuration => _configuration = configuration)
              .ExposeConfiguration(x=>x.SetProperty(NHibernate.Cfg.Environment.ReleaseConnections, "on_close"))
              .BuildSessionFactory();
        }

        public void BuildSchema()
        {

            Session = _sessionFactory.OpenSession();

            new SchemaExport(_configuration).Execute(true, true, false, Session.Connection, Console.Out);
        }

        public void Dispose()
        {
            Session.Dispose();
        }

    }
}
