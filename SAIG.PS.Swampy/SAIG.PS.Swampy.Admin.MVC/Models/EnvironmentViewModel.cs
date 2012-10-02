﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAIG.PS.Swampy.Admin.MVC.Models
{
    public class EnvironmentViewModel
    {
        public string environmentName { get; set; }

        public List<EndpointViewModel> Endpoints { get; set; } 
        
        public class EndpointViewModel
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public string Type { get; set; }
            public string Description { get; set; }
        }
    }
}