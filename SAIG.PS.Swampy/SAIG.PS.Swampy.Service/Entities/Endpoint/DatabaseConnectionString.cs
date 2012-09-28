using System;
using System.Data.Common;

namespace SAIG.PS.Swampy.Service.Entities.Endpoint
{
    /// <summary>
    /// SQL Server Connection String endpoint type 
    /// </summary>
    public class DatabaseConnectionString : EndpointBase
    {
        public override string TypeName { 
            get { return "Database Connection String"; }
        }

        public override bool IsValid(string connectionString)
        {
            try
            {
                var connectionTester = new DbConnectionStringBuilder();
                connectionTester.ConnectionString = connectionString;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
