using NUnit.Framework;
using Swampy.Business.Contract.Validators;
using Swampy.UnitTest.Helpers;

namespace Swampy.UnitTest.Tests.Contract.Validators
{
    [TestFixture]
    public class DatabaseConnectionStringFluentValidatorTest
    {
        [Test]   
        public void url_correctly_validates()
        {

            var underTest = new TestFluentValidator<DB>()
                {
                    v => v.RuleFor(x => x.ConnectionString).SetValidator(new DatabaseConnectionStringFluentValidator())
                };

            
            var result = underTest.Validate(new DB() { ConnectionString = @"Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;" });
            Assert.IsTrue(result.IsValid);

            result = underTest.Validate(new DB() { ConnectionString = @"Data Source=myServerAddress;Initial Catalog=myInstance\myDataBase;User Id=myUsername;Password=myPassword;" });
            Assert.IsTrue(result.IsValid);


            result = underTest.Validate(new DB() { ConnectionString = "rubb ish" });
            Assert.IsFalse(result.IsValid);

        }


        class DB
        {
            public string ConnectionString { get; set; }
        }

    }
}
