using System;
using System.Collections.Generic;

namespace Swampy.Admin.Web.Models.OperationModels.Endpoint
{
    
    public class CreateEndpoint
    {
        public int Id { get; set; }

        public IDictionary<string, Type> EndpointTypes { get; set; }
        public string SelectedType { get; set; }

        public string EnvironmentName { get; set; }

        public CreateSimpleEndpoint Endpoint { get; set; }

        public string Description { get; set; }
    }

   
}
