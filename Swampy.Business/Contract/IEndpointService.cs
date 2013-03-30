namespace Swampy.Business.Contract
{
    
    public interface ISwampyEndpointService
    {
        KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication);

        KeyPair GetSingleEndpoint(string environment, string key, string callingApplication);
    }
}
