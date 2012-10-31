using System.Collections.Generic;

namespace Swampy.Admin.Web.Models.Operation
{
    public class CreateEndpointOperationModel
    {
        public List<string> EndpointTypes { get
        {
            return new List<string>{"Simple", "SQL"};    
        }
        } 

        public string EnvironmentName { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }
    }
}