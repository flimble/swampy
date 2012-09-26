using System;
using System.Data.Common;
using log4net;

namespace SAIG.PS.Swampy.Service.Endpoint
{
    public class DatabaseConnectionString : EndpointBase
    {

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
