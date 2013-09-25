using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.Id;
using NHibernate.Type;
using NHibernate.Util;

namespace Swampy.Business.Infrastructure.NHibernate
{
    public class CustomTableGenerator : TableHiLoGenerator
    {

        private static readonly IInternalLogger log = LoggerProvider.LoggerFor(typeof(TableHiLoGenerator));

        /// <summary>
        /// The name of the max lo parameter.
        /// </summary>
        public const string MaxLo = "max_lo";

        private long hi;
        private long lo;
        private long maxLo;
        private System.Type returnClass;

        #region IConfigurable Members

        /// <summary>
        /// Configures the TableHiLoGenerator by reading the value of <c>table</c>, 
        /// <c>column</c>, <c>max_lo</c>, and <c>schema</c> from the <c>parms</c> parameter.
        /// </summary>
        /// <param name="type">The <see cref="IType"/> the identifier should be.</param>
        /// <param name="parms">An <see cref="IDictionary"/> of Param values that are keyed by parameter name.</param>
        /// <param name="dialect">The <see cref="Dialect"/> to help with Configuration.</param>
        public override void Configure(IType type, IDictionary<string, string> parms, Dialect dialect)
        {
            base.Configure(type, parms, dialect);

            TableName = PropertiesHelper.GetString(TableParamName, parms, DefaultTableName);
            NextHighColumnName = PropertiesHelper.GetString(ColumnParamName, parms, DefaultColumnName);
            TableKeyColumnName = PropertiesHelper.GetString("table_key_column", parms, DefaultTableKeyColumnName);
            TableKey = PropertiesHelper.GetString("table_key_value", parms, "");
            AllEntityNames = PropertiesHelper.GetString("all_entities", parms, ""); 
        }

        #endregion
        

    

        protected string TableName { get; set; }
        protected string NextHighColumnName { get; set; }
        protected string TableKey { get; set; }
        protected string TableKeyColumnName { get; set; }
        private string DefaultTableKeyColumnName = "TableKey";
        protected string AllEntityNames { get; set; }              

        

        public override string[] SqlCreateStrings(Dialect dialect)
        {            
            var createcommand = new StringBuilder("create table " + TableName + " ( " + NextHighColumnName + " " + dialect.GetTypeName(columnSqlType) + ", ");
            createcommand.AppendLine(TableKeyColumnName + " " + "VARCHAR(125)");
            createcommand.AppendLine(")");

            var rows = AllEntityNames.Split(',');

            var command = new List<string> {createcommand.ToString()};

            foreach (var row in rows)
            {
                command.Add(string.Format("insert into " + TableName + " values ( 1,'{0}' )", row));
            }

            return command.ToArray();

        }


    }
}
