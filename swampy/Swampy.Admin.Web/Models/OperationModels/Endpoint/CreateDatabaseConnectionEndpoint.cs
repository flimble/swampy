using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;

namespace Swampy.Admin.Web.Models.OperationModels
{
    [Validator(typeof(CreateSqlConnectionStringValidator))]
    public class CreateDatabaseConnectionEndpointOperationModel : CreateEndpointBase
    {
        public string DatabaseConnectionString { get; set; }
    }

    public class CreateSqlConnectionStringValidator :
        CreateEndpointBaseValidator<CreateDatabaseConnectionEndpointOperationModel>
    {
        public CreateSqlConnectionStringValidator()
        {

            RuleFor(x => x.DatabaseConnectionString).Must(BeValidDatabaseConnectionString);

        }

        private bool BeValidDatabaseConnectionString(string connectionString)
        {
            var csb = new DbConnectionStringBuilder();
            try
            {
                csb.ConnectionString = connectionString;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }


}