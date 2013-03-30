using System.Collections.Generic;

namespace Swampy.Business.DomainModel.Entities
{
    public class TokenizedConfigParser
    {
        private readonly IList<string> _globalTokens;

        public TokenizedConfigParser(IList<string> globalTokens)
        {
            _globalTokens = globalTokens;
        }         
    }
}
