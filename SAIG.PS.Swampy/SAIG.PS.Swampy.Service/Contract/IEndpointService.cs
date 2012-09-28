using System.ServiceModel;

namespace SAIG.PS.Swampy.Service.Contract
{
    /// <summary>
    /// WCF contract service for applications to connect to.
    /// This contract is readonly and is used to retrieve endpoint information by all applications in the system.
    /// </summary>
    [ServiceContract]
    public interface IEndpointService
    {
        [OperationContract]
        KeyPair[] GetEndpoints(string environment, string[] keys);

        [OperationContract]
        KeyPair GetSingleEndpoint(string environment, string key);
    }
}
