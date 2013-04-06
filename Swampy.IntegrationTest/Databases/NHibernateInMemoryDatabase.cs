using System;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Swampy.Business.Infrastructure.NHibernate;

namespace Swampy.UnitTest.Helpers
{
    public class NHibernateInMemoryDatabase : INHibernateDatabase
    {
        protected Configuration Configuration;
        private static ISessionFactory _sessionFactory;
        public ISession Session { get; set; }

    public NHibernateInMemoryDatabase()
        {
            _sessionFactory = CreateSessionFactory();            
            BuildSchema();
        }

        private ISessionFactory CreateSessionFactory()
        {
            var dbConfig = SQLiteConfiguration.Standard.InMemory().ShowSql();

            return 
               NHibernateConfigurationFactory.Configuration(dbConfig)
              .ExposeConfiguration(configuration => Configuration = configuration)
              .ExposeConfiguration(x=>x.SetProperty(NHibernate.Cfg.Environment.ReleaseConnections, "on_close"))
              .BuildSessionFactory();
        }

        public void BuildSchema()
        {
            Session = _sessionFactory.OpenSession();
            new SchemaExport(Configuration).Execute(true, true, false, Session.Connection, Console.Out);
        }

        public void Dispose()
        {
            Session.Dispose();
        }

    }
}
