using System.Collections.Generic;
using SAIG.PS.Swampy.Service.Entities.Endpoint;

namespace SAIG.PS.Swampy.Service.Entities
{
    public class Environment : EntityBase
    {
        public string Name { get; set; }

        public Environment(string name) : this()
        {
            Name = name;
        }

        public Environment()
        {
            Endpoints = new List<EndpointBase>();
        }


        public IList<EndpointBase> Endpoints { get; set; }
    }
}
