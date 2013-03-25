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
            var underTest = new ServiceUrlValidator();
            Assert.IsFalse(underTest.IsValid(@"http://admin.sit1.property. saiglobal.com"));

            Assert.IsTrue(underTest.IsValid(@"http://admin.sit1.property.saiglobal.com"));
        }
    }
}
