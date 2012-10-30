using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Swampy.Admin.Web.Models.OperationModels
{
    public class CreateServerEndpoint : CreateEndpointBase
    {
        public string ServerName { get; set; }
        public string Domain { get; set; }
    }
}