using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAIG.PS.Swampy.Service.Endpoint
{
    public abstract class EndpointBase : IEndpointValidator
    {
        public virtual string Key { get; set; }

        public virtual string Value { get; set; }

        #region Implementation of IEndpointValidator

        public abstract bool IsValid(string endpoint);

        #endregion
    }
}
