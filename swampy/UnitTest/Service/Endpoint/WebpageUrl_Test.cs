using NUnit.Framework;
using Swampy.Domain.Entities.Endpoint;

namespace Swampy.UnitTest.Service.Endpoint
{
    [TestFixture]
    public class WebpageUrl_Test
    {
        [Test]
        public void url_correctly_validates()
        {
            var underTest = new WebpageUrl();
            underTest.Value = "http://admin.sit1.property. saiglobal.com";
            Assert.IsFalse(underTest.IsValid());

            underTest.Value = "http://admin.sit1.property.saiglobal.com";
            Assert.IsTrue(underTest.IsValid());
        }
    }
}
