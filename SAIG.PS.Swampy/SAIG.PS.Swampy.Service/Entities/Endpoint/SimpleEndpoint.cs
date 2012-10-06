using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAIG.PS.Swampy.Service.Entities.Endpoint
{
    public class SimpleEndpoint : EndpointBase
    {
        public override bool IsValid(string endpoint)
        {
            return !string.IsNullOrWhiteSpace(endpoint);
        }

        public override bool Test(string endpoint)
        {
            return true;
        }

        public override string TypeName
        {
            get { return "Simple String Endpoint"; }
        }
    }
}
