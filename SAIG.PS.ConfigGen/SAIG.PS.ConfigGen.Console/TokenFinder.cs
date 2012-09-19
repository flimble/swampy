using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SAIG.PS.ConfigGen.Console
{
    public class TokenFinder
    {
        public List<string> GetTokens(string input)
        {
            string pattern = @"\[%.*?%\]";

            var result = new List<string>();

            foreach (var m in Regex.Matches(input, pattern))
            {
                string match = m.ToString();

                if(!result.Contains(match))
                    result.Add(match);
                
            }
            return result;
        }


        public List<string> StripTokens(List<string> tokenList)
        {
            return tokenList.Select(token => RemoveNCharsEachSide(token, 2)).ToList();
        }

        private string RemoveNCharsEachSide(string toStrip, int countToStripEachSide)
        {
            return toStrip.Substring(countToStripEachSide, toStrip.Length - (countToStripEachSide * 2));
        }
    }
}
