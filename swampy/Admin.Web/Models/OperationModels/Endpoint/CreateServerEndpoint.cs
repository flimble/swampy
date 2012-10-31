namespace Swampy.Admin.Web.Models.OperationModels.Endpoint
{
    public class CreateServerEndpoint : CreateEndpointBase
    {
        public string ServerName { get; set; }
        public string Domain { get; set; }
    }
}