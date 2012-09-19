using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using NUnit.Framework;
using SAIG.PS.ConfigGen.Console;

namespace SAIG.PS.ConfigGen.UnitTest
{
    [TestFixture]
    public class TokenReplacerTest
    {
        [Test]
        public void Token_Replacer_For_Single_Token_Is_One()
        {
            //arrange
            var tokenReplacementValueMap = new Dictionary<string, string>
                                               {
                                                   { "[%Token1%]","ba" }
                                               };

            string templateXml =
                @"<?xml version=""1.0""?>
                         <configuration>
                            <appSettings>
                                <add key=""CommonDBConnectionString"" value=""[%Token1%]"" />
                            </appSettings>
                         </configuration>";


            string expected =
                            @"<?xml version=""1.0""?>
                         <configuration>
                            <appSettings>
                                <add key=""CommonDBConnectionString"" value=""ba"" />
                            </appSettings>
                         </configuration>";


            var underTest = new TokenReplacer();

            string result = underTest.Replace(templateXml, tokenReplacementValueMap);

            Assert.AreEqual(expected, result);

        }


        [Test]
        public void Token_Replacer_For_Multiple_Tokens()
        {
            //arrange
            var tokenReplacementValueMap = new Dictionary<string, string>
                                               {
                                                   { "[%Token1%]","ba" },
                                                   { "[%Token2%]","fa" }
                                               };

            string templateXml =
                @"<?xml version=""1.0""?>
                         <configuration>
                            <appSettings>
                                <add key=""CommonDBConnectionString"" value=""[%Token1%]"" />
                                <add key=""SSRDBConnectionString"" value=""[%Token2%]"" />
                            </appSettings>
                         </configuration>";


            string expected =
                            @"<?xml version=""1.0""?>
                         <configuration>
                            <appSettings>
                                <add key=""CommonDBConnectionString"" value=""ba"" />
                                <add key=""SSRDBConnectionString"" value=""fa"" />
                            </appSettings>
                         </configuration>";


            var underTest = new TokenReplacer();

            string result = underTest.Replace(templateXml, tokenReplacementValueMap);

            Assert.AreEqual(expected, result);

        }

    }
}
