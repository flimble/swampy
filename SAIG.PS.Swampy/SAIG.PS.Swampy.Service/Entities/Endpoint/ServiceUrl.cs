using System;

namespace SAIG.PS.Swampy.Service.Entities.Endpoint
{
    public class ServiceUrl : EndpointBase
    {
        public override string TypeName
        {
            get { return "Wcf Service Url"; }
        }

        public override bool IsValid(string url)
        {
            return (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute));
        }

       
    }
}
