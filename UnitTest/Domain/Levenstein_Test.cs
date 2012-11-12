using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Swampy.Domain.Entities;

namespace Swampy.UnitTest.Domain
{
    [TestFixture]
    public class Levenstein_Test
    {
        [Test]
        public void Test()
        {
            var a = new Levenshtein();

            var resulta = a.LD("abc", "abc");
            var resultb = a.LD("abc", "abcd");
            var resultc = a.LD("abc", "adc");
            var resulte = a.LD("CommonDBConnectionString", "CommonDBConnectsionString");
            var resultf = a.LD("ReportingServices.Username", "ReportServiceUsername");

            Assert.AreEqual(0, resulta);
            Assert.Less(50, resultb);
            Assert.Less(50, resultc);
            Assert.Less(50, resulte);
            Assert.Less(50, resultf);
            
            var resultd = a.LD("lkasjdflkdoqiuweroieruweo", "oiquoririewieroeu");
            
            Assert.Greater(50, resultd);

        }
    }
}
