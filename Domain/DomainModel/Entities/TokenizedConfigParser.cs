﻿using System.Collections.Generic;

namespace Swampy.Domain.Entities
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
