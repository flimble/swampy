using System;
using System.Collections.Generic;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.Models.ReadModels
{
    public class EnvironmentReadModel
    {
        public string environmentName { get; set; }

        public List<string> allEnvironments { get; set; }

        public List<EndpointViewModel> Endpoints { get; set; }


        public IEnumerable<ConfigurationItemType> EndpointTypes { get; set; }
        public string SelectedType { get; set; }

        public class EndpointViewModel
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public string Type { get; set; }
            public string Description { get; set; }
        }
    }
}
