using System;
using System.Data.Common;

namespace Swampy.Service.Entities.Endpoint
{
    /// <summary>
    /// SQL Server Connection String endpoint type 
    /// </summary>
    public class DatabaseConnectionString : EndpointBase
    {
        public override string TypeName { 
            get { return "Database Connection String"; }
        }

        public override bool IsValid()
        {
            try
            {
                var connectionTester = new DbConnectionStringBuilder();
                connectionTester.ConnectionString = Value;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Test()
        {
            throw new NotImplementedException();
        }
    }
}
