using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Swampy.Business.Infrastructure.NHibernate;
using Swampy.Business.Infrastructure.NHibernate.Conventions;

namespace Swampy.UnitTest.Helpers
{
    public class NHibernateSchemaUpdateDatabase : INHibernateDatabase
    {
        protected Configuration Configuration;
        public ISession Session { get; set; }
        public void BuildSchema()
        {
            var sqlServerConfiguration = MsSqlConfiguration.MsSql2008
                                                   .ConnectionString(
                                                       x =>
                                                       x.Server(@".\local")
                                                        .TrustedConnection()
                                                        .Database("Swampy"))
                                                   .ShowSql();

            NHibernateConfigurationFactory.Configuration(sqlServerConfiguration)                             
                  .ExposeConfiguration(
                   cfg =>
                       {                           
                           Configuration = cfg;    
                           
                       })
                   .BuildSessionFactory();

            var executingDir = new Uri(Directory.GetCurrentDirectory());
            var rootDir = new Uri(executingDir, @"../../");
            var dbScriptsDir = Path.Combine(rootDir.LocalPath,
                                            @"Swampy.Database\2.Tables and Data (MODIFICATIONS WILL REQUIRE DATABASE REFRESH)");

            var files = from file in Directory.GetFiles(dbScriptsDir)
                        orderby file descending
                        select file;


            int seed = 0;
            if (files.Any())
            {
                string latestFile = Path.GetFileName(files.First());
                int number = int.Parse(latestFile.Substring(0, 4));

                seed = number / 10;


            }
            int newScriptNo = (++seed) * 10;
            string fileName = string.Format("{0}.update.sql", newScriptNo.ToString("0000"));

            var newScript = Path.Combine(dbScriptsDir, fileName);





            using (var file = new FileStream(newScript, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(file))
            {
                Action<string> updateExport = x =>
                {
                    sw.Write(x);
                    Console.Write(x);
                };

                new SchemaUpdate(Configuration).Execute(updateExport, false);
                sw.Close();
            }
        }


        public void Dispose()
        {
            Session.Dispose();
        }
    }
}
