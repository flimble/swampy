using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Swampy.Domain.Entities
{
    public class TokenBuilder : ITokenBuilder
    {
        public List<string> TokensFound { get; private set; }

        public void SearchForTokens(string input)
        {
            string pattern = @"\[%.*?%\]";

            var result = new List<string>();

            foreach (var m in Regex.Matches(input, pattern))
            {
                string match = m.ToString();

                if (!result.Contains(match))
                {
                    result.Add(match);
                }

            }
            TokensFound = result;
        }




        public string StripTokens(string toStrip)
        {
            return toStrip.Substring(2, toStrip.Length - 4);
        }

        public string AppendTokens(string toAppend)
        {
            return string.Format("[%{0}%]", toAppend);
        }
    }
}
