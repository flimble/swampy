using System;

namespace SAIG.PS.Swampy.Service.Entities.Endpoint
{
    /// <summary>
    /// A webpage url environent endpoint
    /// </summary>
    public class WebpageUrl : EndpointBase
    {
        public override bool Test(string endpoint)
        {
            throw new NotImplementedException();
        }

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
