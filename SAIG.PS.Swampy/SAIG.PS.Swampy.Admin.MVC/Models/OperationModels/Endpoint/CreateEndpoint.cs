using System;
using System.Collections.Generic;

namespace SAIG.PS.Swampy.Admin.MVC.Models.OperationModels.Endpoint
{
    
    public class CreateEndpoint
    {

        public IDictionary<string, Type> EndpointTypes { get; set; }

        public string EnvironmentName { get; set; }

        public CreateEndpointBase Endpoint { get; set; }
    }

   
}