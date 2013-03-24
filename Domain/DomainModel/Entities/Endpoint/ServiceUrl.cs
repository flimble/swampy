using System;

namespace Swampy.Domain.Entities.Endpoint
{
    /// <summary>
    /// A web or Wcf Service Url endpoint
    /// </summary>
    public class ServiceUrl : Endpoint
    {
        public override bool Test()
        {
            throw new NotImplementedException();
        }

        public override string TypeName
        {
            get { return "Wcf Service Url"; }
        }

        public override bool IsValid()
        {
            return (Uri.IsWellFormedUriString(Value, UriKind.RelativeOrAbsolute));
        }

       
    }
}
