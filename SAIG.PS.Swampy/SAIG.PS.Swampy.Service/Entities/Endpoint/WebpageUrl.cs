using System;

namespace SAIG.PS.Swampy.Service.Entities.Endpoint
{
    /// <summary>
    /// A webpage url environent endpoint
    /// </summary>
    public class WebpageUrl : EndpointBase
    {
        public override bool Test()
        {
            throw new NotImplementedException();
        }

        public override string TypeName
        {
            get { return "Web Page"; }
        }

        public override bool IsValid()
        {
            return (Uri.IsWellFormedUriString(Value, UriKind.RelativeOrAbsolute));
        }

       
    }
}
