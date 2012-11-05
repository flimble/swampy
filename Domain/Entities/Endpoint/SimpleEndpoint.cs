namespace Swampy.Domain.Entities.Endpoint
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
