using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAIG.PS.Swampy.Service;
using SAIG.PS.Swampy.UnitTest.Fakes;

namespace SAIG.PS.ConfigGen.Console
{
    /// <summary>
    /// Wrapper for Swampy Environment Service 
    /// </summary>
    public class SwampyProxy
    {
        IEndpointService _environmentService = new FakeEndpointService();


        public Dictionary<string, string> GetValues(IList<string> keys)
        {
            var endpoints = _environmentService.GetEndpoints("SIT1", keys.ToArray());

            return endpoints.ToDictionary(x => x.Key, y => y.Value);
        }
    }
}
