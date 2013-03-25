using NUnit.Framework;
using Swampy.Business.Contract.Validators;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.UnitTest.Service.Endpoint
{
    [TestFixture]
    public class WebpageUrl_Test
    {
        [Test]
        public void url_correctly_validates()
        {

            var underTest = new TestValidator<MockUrl>()
                {
                    v => v.RuleFor(x => x.Url).SetValidator(new UrlValidator())
                };


            var result = underTest.Validate(new MockUrl {Url = @"http://admin.sit1.property. saiglobal.com"});
            Assert.IsFalse(result.IsValid);


            result = underTest.Validate(new MockUrl {Url = @"http://admin.sit1.property.saiglobal.com"});
            Assert.IsTrue(result.IsValid);

        }


        public class MockUrl
        {
            public string Url { get; set; }
        }
    }
}
