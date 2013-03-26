using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Swampy.Business.Infrastructure.NHibernate;

namespace Swampy.UnitTest
{
    [TestFixture]
    public class SchemaUpdateGenerator
    {
        private Configuration Configuration;
        private ISessionFactory SessionFactory;




        [Test]
        [Explicit]
        public void generate_for_test()
        {

            var sqlServerConfiguration = MsSqlConfiguration.MsSql2008
                                                               .ConnectionString(
                                                                   x =>
                                                                   x.Server("(local)")
                                                                    .TrustedConnection()
                                                                    .Database("Swampy"))
                                                               .ShowSql();

            NHibernateConfigurationFactory.Configuration(sqlServerConfiguration)
                   .ExposeConfiguration(cfg => Configuration = cfg)
                   .BuildSessionFactory();

            //var session = SessionFactory.OpenSession();

            var executingDir = new Uri(Directory.GetCurrentDirectory());
            var rootDir = new Uri(executingDir, @"../../");
            var dbScriptsDir = Path.Combine(rootDir.LocalPath,
                                            @"Swampy.Database\2.Tables and Data (MODIFICATIONS WILL REQUIRE DATABASE REFRESH)");

            var newScript = Path.Combine(dbScriptsDir, "0010.update.sql");



            

            using (var file = new FileStream(newScript, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(file))
            {
                Action<string> updateExport = x =>
                {
                    sw.Write(x);
                };

                new SchemaUpdate(Configuration).Execute(updateExport, false);
                sw.Close();
            }

            
        }


    }
}