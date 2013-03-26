using NUnit.Framework;
using Swampy.Business.Contract.Validators;
using Swampy.Business.DomainModel.Entities;
using Swampy.UnitTest.Helpers;

namespace Swampy.UnitTest.Service.Endpoint
{
    [TestFixture]
    public class UrlValidatorTest
    {
        [Test]
        public void url_correctly_validates()
        {

            var underTest = new TestFluentValidator<MockUrl>()
                {
                    v => v.RuleFor(x => x.Url).SetValidator(new UrlFluentValidator())
                };


            var result = underTest.Validate(new MockUrl {Url = @"http://admin.sit1.property. saiglobal.com"});
            Assert.IsFalse(result.IsValid);


            result = underTest.Validate(new MockUrl {Url = @"http://admin.sit1.property.saiglobal.com"});
            Assert.IsTrue(result.IsValid);

        }


        class MockUrl
        {
            public string Url { get; set; }
        }
    }
}
