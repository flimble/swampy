﻿using System.ServiceModel;

namespace Swampy.Domain.Contract
{
    /// <summary>
    /// WCF contract service for applications to connect to.
    /// This contract is readonly and is used to retrieve endpoint information by all applications in the system.
    /// </summary>
    public interface ISwampyEndpointService
    {
        KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication);

        KeyPair GetSingleEndpoint(string environment, string key, string callingApplication);
    }
}
