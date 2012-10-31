using System.ServiceModel;

namespace Swampy.Domain.Contract
{
    
    public interface ISwampyEndpointService
    {
        KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication);

        KeyPair GetSingleEndpoint(string environment, string key, string callingApplication);
    }
}
