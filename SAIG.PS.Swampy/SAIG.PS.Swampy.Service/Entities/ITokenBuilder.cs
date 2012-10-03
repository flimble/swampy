using System.Collections.Generic;

namespace SAIG.PS.Swampy.Service.Entities
{
    public interface ITokenBuilder
    {
        List<string> TokensFound { get; }
        void SearchForTokens(string input);
        string StripTokens(string toStrip);
        string AppendTokens(string toAppend);
    }
}