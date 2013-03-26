using System.Collections.Generic;

namespace Swampy.Business.DomainModel.Entities.Interfaces
{
    public interface ITokenBuilder
    {
        List<string> TokensFound { get; }
        void SearchForTokens(string input);
        string AddTokenWrap(string toAppend);
    }
}