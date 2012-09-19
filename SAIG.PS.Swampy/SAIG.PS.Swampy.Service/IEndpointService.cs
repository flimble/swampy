using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SAIG.PS.Swampy.Service
{
    [ServiceContract]
    public interface IEndpointService
    {
        [OperationContract]
        KeyPair[] GetEndpoints(string environment, string[] keys);
    }
}
