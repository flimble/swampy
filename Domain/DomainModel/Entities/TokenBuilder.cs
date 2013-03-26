using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Swampy.Business.DomainModel.Entities.Interfaces;

namespace Swampy.Business.DomainModel.Entities
{
    public class TokenBuilder : ITokenBuilder
    {
        public List<string> TokensFound { get; private set; }

        public void SearchForTokens(string input)
        {
            string pattern = @"{.*?}";

            var result = new List<string>();

            foreach (var m in Regex.Matches(input, pattern))
            {
                string match = m.ToString();

                if (!result.Contains(match))
                {
                    result.Add(RemoveTokenWrap(match));
                }

            }
            TokensFound = result;
        }

        public bool HasTokens
        {
            get { return this.TokensFound.Any(); }
        }


        private string RemoveTokenWrap(string toStrip)
        {
            return toStrip.Substring(1, toStrip.Length - 2);
        }

        public string AddTokenWrap(string toAppend)
        {
            return string.Format("{{{0}}}", toAppend);
        }
    }
}
