using System.Collections.Generic;
using Swampy.Domain.Entities;
using Swampy.Domain.Entities.Endpoint;
using Swampy.Business.DomainModel.ValueObjects;

namespace Swampy.Business.DomainModel.Entities
{
    public class Environment : EntityBase
    {
        public virtual string Name { get; set; }

        public Environment(string name) : this()
        {
            Name = name;
        }

        public Environment(string name, string domain) : this()
        {
            Name = name;
            Domain = new ValueObjects.Domain(domain);
        }

        public virtual ValueObjects.Domain Domain { get; set; }

        protected Environment()
        {
            Endpoints = new List<IEndpoint>();
            SimpleEndpoints = new List<ConfigurationItem>();
            Servers = new List<Server>();
        }


        public virtual IList<IEndpoint> Endpoints { get; set; }
        public virtual IList<ConfigurationItem> SimpleEndpoints { get; set; }

        public virtual IList<Server> Servers { get; protected set; } 

        public virtual void AddServer(string key, string name)
        {
            Servers.Add(new Server
                {
                    Domain = this.Domain,
                    Name = name,
                    Key = key,
                    Environment = this
                });

        }
        
    }
}
