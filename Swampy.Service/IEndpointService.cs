using System.ServiceModel;
using NHibernate;
using Swampy.Business.Contract;

namespace Swampy.Service
{
    /// <summary>
    /// WCF contract service for applications to connect to.
    /// This contract is readonly and is used to retrieve endpoint information by all applications in the system.
    /// </summary>
    [ServiceContract]
    public interface IEndpointService
    {
        [OperationContract]
        KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication);

        [OperationContract]
        KeyPair GetSingleEndpoint(string environment, string key, string callingApplication);  
       
    }
}
