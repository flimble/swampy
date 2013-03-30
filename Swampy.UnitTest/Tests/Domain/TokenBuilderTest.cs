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
    public class TokenBuilderTest
    {
        [Test]
        public void Single_token_hastoken()
        {
            var underTest = new TokenBuilder();

            underTest.SearchForTokens("abcd{abc}");
            Assert.IsTrue(underTest.HasTokens);

            underTest.SearchForTokens("abcd");
            Assert.IsFalse(underTest.HasTokens);

            underTest.SearchForTokens("abcd");
            Assert.IsFalse(underTest.HasTokens);

            underTest.SearchForTokens("abcd[%a");
            Assert.IsFalse(underTest.HasTokens);
        }

        [Test]
        public void Single_token_returns_correctly_escaped_token()
        {
            var underTest = new TokenBuilder();

            underTest.SearchForTokens("abcd{abc}");
            Assert.AreEqual(1, underTest.TokensFound.Count);     
            Assert.AreEqual("abc", underTest.TokensFound.Single());                      
        }

    }
}
