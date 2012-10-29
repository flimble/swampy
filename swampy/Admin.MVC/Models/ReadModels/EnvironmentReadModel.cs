﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Swampy.Admin.MVC.Models
{
    public class EnvironmentReadModel
    {
        public string environmentName { get; set; }

        public List<string> allEnvironments { get; set; }

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