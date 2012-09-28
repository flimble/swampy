using System;

namespace SAIG.PS.Swampy.Service.Entities.Endpoint
{
    /// <summary>
    /// A web or Wcf Service Url endpoint
    /// </summary>
    public class ServiceUrl : EndpointBase
    {
        public override bool Test(string endpoint)
        {
            throw new NotImplementedException();
        }

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
