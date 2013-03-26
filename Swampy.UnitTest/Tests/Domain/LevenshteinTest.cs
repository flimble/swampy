using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.UnitTest.Domain
{
    [TestFixture]
    public class LevenshteinTest
    {
        [Test]
        public void exact_match_returns_zero()
        {
            var a = new Levenshtein();

            var resulta = a.LD("abc", "abc");

            //exact match should be zero
            Assert.AreEqual(0, resulta);

          
           

        }

        [Test]
        public void close_match_returns_value_lessthan_50()
        {
            var a = new Levenshtein();


            var resultb = a.LD("abc", "abcd");
            var resultc = a.LD("abc", "adc");
            var resulte = a.LD("CommonDBConnectionString", "CommonDBConnectsionString");
            var resultf = a.LD("ReportingServices.Username", "ReportServiceUsername");



            //close matches should be less than 50
            Assert.Less(resultb, 50);
            Assert.Less(resultc, 50);
            Assert.Less(resulte, 50);
            Assert.Less(resultf, 50);
        }

        [Test]
        public void no_match_returns_value_greaterthan_50()
        {
            var a = new Levenshtein();

            //unalike should be greater than 50
            var resultd = a.LD("lkasjdflkdoqiuweroieruweo", "oiquoririewieroeu");

            Assert.Greater(resultd, 50);
        }
    }
}
