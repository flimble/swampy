using System;
using System.Data.Common;
using FluentValidation.Validators;

namespace Swampy.Business.Contract.Validators
{
    public class DatabaseConnectionStringValidator : PropertyValidator
    {
        public DatabaseConnectionStringValidator() 
		: base("Property {PropertyName} must be a valida database connection string") {
		
	}


        protected override bool IsValid(PropertyValidatorContext context)
        {
            try
            {
                var connectionString = context.PropertyValue as string;

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
