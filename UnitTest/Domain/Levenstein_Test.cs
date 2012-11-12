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

            a.LD("abc", "abcd");
        }
    }
}
