using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAIG.PS.Swampy.Service.Endpoint;

namespace SAIG.PS.Swampy.Service
{
    public class SystemEnvironment : EntityBase
    {
        public string Name { get; set; }

        public SystemEnvironment(string name) : this()
        {
            Name = name;
        }

        public SystemEnvironment()
        {
            Endpoints = new List<EndpointBase>();
        }


        public IList<EndpointBase> Endpoints { get; set; }
    }
}
