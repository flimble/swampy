using NUnit.Framework;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.UnitTest.Tests.Domain
{
    [TestFixture]
    public class ServerTest
    {
        [Test]
        public void FQDN_is_servername_and_domain()
        {
            var underTest = new SwampyServer
                {
                    SwampyEnvironment = new SwampyEnvironment("SIT1", "saig.frd.global"),
                    Key = "SSRDBServer",
                    Name = "ausydhq-pstsq04"
                };
            
            Assert.AreEqual("ausydhq-pstsq04.saig.frd.global", underTest.FullyQualifiedDomainName);
        }

    }
}
