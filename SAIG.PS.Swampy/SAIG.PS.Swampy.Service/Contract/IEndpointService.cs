using System.ServiceModel;

namespace SAIG.PS.Swampy.Service.Contract
{
    [ServiceContract]
    public interface IEndpointService
    {
        [OperationContract]
        KeyPair[] GetEndpoints(string environment, string[] keys);

        [OperationContract]
        KeyPair GetSingleEndpoint(string environment, string key);
    }
}
