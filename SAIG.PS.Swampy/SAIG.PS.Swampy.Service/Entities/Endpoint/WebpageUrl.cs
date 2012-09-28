using System;

namespace SAIG.PS.Swampy.Service.Entities.Endpoint
{
    public class WebpageUrl : EndpointBase
    {
        public override string TypeName
        {
            get { return "Web Page"; }
        }

        public override bool IsValid(string url)
        {
            return (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute));
        }

       
    }
}
