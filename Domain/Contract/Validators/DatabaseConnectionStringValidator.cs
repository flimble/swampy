using System;
using System.Data.Common;

namespace Swampy.Business.Contract.Validators
{
    public class DatabaseConnectionStringValidator
    {
        public bool IsValid(string toValidate)
        {
            try
            {
                var connectionTester = new DbConnectionStringBuilder();
                connectionTester.ConnectionString = toValidate;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
