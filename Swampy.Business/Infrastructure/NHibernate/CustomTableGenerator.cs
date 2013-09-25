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

            maxLo = PropertiesHelper.GetInt64(MaxLo, parms, Int16.MaxValue);
            lo = maxLo + 1; // so we "clock over" on the first invocation
            returnClass = type.ReturnedClass;
        }

        #endregion
        

        /// <summary>
        /// Generate a <see cref="Int64"/> for the identifier by selecting and updating a value in a table.
        /// </summary>
        /// <param name="session">The <see cref="ISessionImplementor"/> this id is being generated in.</param>
        /// <param name="obj">The entity for which the id is being generated.</param>
        /// <returns>The new identifier as a <see cref="Int64"/>.</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public override object Generate(ISessionImplementor session, object obj)
        {
            if (maxLo < 1)
            {
                //keep the behavior consistent even for boundary usages
                long val = Convert.ToInt64(base.Generate(session, obj));
                if (val == 0)
                    val = Convert.ToInt64(base.Generate(session, obj));
                return IdentifierGeneratorFactory.CreateNumber(val, returnClass);
            }
            if (lo > maxLo)
            {
                long hival = Convert.ToInt64(base.Generate(session, obj));
                lo = (hival == 0) ? 1 : 0;
                hi = hival * (maxLo + 1);
                log.Debug("New high value: " + hival);
            }

            return IdentifierGeneratorFactory.CreateNumber(hi + lo++, returnClass);
        }

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

            /*string create = "create table " + tableName + " (";
            string insert = "insert into " + tableName + " values (";
            
            foreach (string s in allColumns)
            {
                create += " " + s + " " + dialect.GetTypeName(columnSqlType) + ",";
                insert += " 1,";
            }
            create = create.Trim(',') + " )";
            insert = insert.Trim(',') + " )";
            return new[] { create, insert };*/
        }


    }
}
