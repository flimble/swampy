using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Iesi.Collections.Generic;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping;


namespace Swampy.Business.Infrastructure.NHibernate
{
    public class PrimaryKeyConvention : IIdConvention
    {
        private const string NHibernateHiLoIdentityTableName = "NHibernateHiLoIdentity";
        private const string NextHiValueColumnName = "NextHigh";
        private const string TableColumnName = "TableKey";
        private const string MaxLo = "1000";

        public void Apply(IIdentityInstance instance)
        {
            string entityName = instance.EntityType.Name;

            instance.Column(entityName + "Id");



            instance.GeneratedBy.Custom<CustomTableGenerator>(
            x =>
                {
                    x.AddParam("max_lo", MaxLo);
                    x.AddParam("table", NHibernateHiLoIdentityTableName);
                    x.AddParam("column", NextHiValueColumnName);
                    x.AddParam("table_key_value", entityName);
                    x.AddParam("table_key_column", TableColumnName);
                    x.AddParam("all_entities", "ConfigurationItem,SwampyEnvironment");
                    x.AddParam("where", string.Format("TableKey = '{0}'", instance.EntityType.Name));
                }
            );
        }

        public static void CreateHighLowScript(Configuration config)
        {
            var sqlServerScript = CreateSqlServerHighLowScript(config);
            config.AddAuxiliaryDatabaseObject(new SimpleAuxiliaryDatabaseObject(sqlServerScript, null, new HashedSet<string> { typeof(SQLiteDialect).FullName }));

            var sqlLiteScript = CreateSqlLiteHighLowScript(config);
            config.AddAuxiliaryDatabaseObject(new SimpleAuxiliaryDatabaseObject(sqlLiteScript, null, new HashedSet<string> { typeof(SQLiteDialect).FullName }));
        }

        private static string CreateSqlLiteHighLowScript(Configuration config)
        {
            var script = new StringBuilder();
            script.AppendFormat("DELETE FROM {0};", NHibernateHiLoIdentityTableName);
            script.AppendLine();
            script.AppendFormat("ALTER TABLE {0} ADD {1} VARCHAR default '';", NHibernateHiLoIdentityTableName, TableColumnName);
            script.AppendLine();                        
            foreach (var tableName in config.ClassMappings.Select(m => m.Table.Name).Distinct())
            {
                script.AppendFormat("INSERT INTO [{0}] ({1}, {2}) VALUES ('[{3}]',1);", NHibernateHiLoIdentityTableName, TableColumnName, NextHiValueColumnName, tableName);
                script.AppendLine();
            }

            return script.ToString();
        }

        private static string CreateSqlServerHighLowScript(Configuration config)
        {
            var script = new StringBuilder();
            script.AppendFormat("DELETE FROM {0};", NHibernateHiLoIdentityTableName);
            script.AppendLine();
            script.AppendFormat("ALTER TABLE {0} ADD {1} VARCHAR(128) NOT NULL;", NHibernateHiLoIdentityTableName, TableColumnName);
            script.AppendLine();
            script.AppendFormat("CREATE NONCLUSTERED INDEX IX_{0}_{1} ON {0} ({1} ASC);", NHibernateHiLoIdentityTableName, TableColumnName);
            script.AppendLine();
            script.AppendLine("GO");
            script.AppendLine();
            foreach (var tableName in config.ClassMappings.Select(m => m.Table.Name).Distinct())
            {
                script.AppendFormat("INSERT INTO [{0}] ({1}, {2}) VALUES ('[{3}]',1);", NHibernateHiLoIdentityTableName, TableColumnName, NextHiValueColumnName, tableName);
                script.AppendLine();
            }

            return script.ToString();
        }
    }
}
