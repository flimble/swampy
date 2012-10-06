using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAIG.PS.Swampy.Service.Entities.Endpoint
{
    public class SimpleEndpoint : EndpointBase
    {
        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Value);
        }

        public override bool Test()
        {
            return true;
        }

        public override string TypeName
        {
            get { return "Simple String Endpoint"; }
        }
    }
}
