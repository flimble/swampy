using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAIG.PS.Swampy.Service;

namespace SAIG.PS.Swampy.UnitTest.Fakes
{
    public class FakeEndpointService : IEndpointService
    {
        #region Implementation of IEndpointService

        public KeyPair[] GetEndpoints(string environment, string[] keys)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
