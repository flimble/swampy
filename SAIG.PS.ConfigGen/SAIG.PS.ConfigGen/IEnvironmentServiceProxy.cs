using System;
using SAIG.PS.ConfigGen.SwampyEnvironments;
namespace SAIG.PS.ConfigGen
{
    public interface IEnvironmentServiceProxy
    {
        KeyPair[] GetEndpoints(string environment, string[] keys, string callingApplication);
        KeyPair GetSingleEndpoint(string environment, string key, string callingApplication);
    }
}
