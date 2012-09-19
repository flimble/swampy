using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SAIG.PS.Swampy.Service
{
    public class DatabaseConnectionString : IEndpointValidator
    {
        public bool IsValid(string connectionString)
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
