using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAIG.PS.Swampy.Service.Endpoint
{
    public class WebpageUrl : IEndpointValidator
    {
        #region Implementation of IEndpointValidator

        public bool IsValid(string url)
        {
            return (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute));
        }

        #endregion
    }
}
