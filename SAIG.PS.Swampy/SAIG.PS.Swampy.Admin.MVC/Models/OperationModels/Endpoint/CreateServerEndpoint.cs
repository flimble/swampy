using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAIG.PS.Swampy.Admin.MVC.Models.OperationModels
{
    public class CreateServerEndpoint : CreateEndpointBase
    {
        public string ServerName { get; set; }
        public string Domain { get; set; }
    }
}