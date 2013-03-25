using System.Linq;
using Swampy.Admin.Web.Models.ReadModels;
using Swampy.Business.DomainModel.Entities;
using Environment = Swampy.Business.DomainModel.Entities.Environment;

namespace Swampy.Admin.Web.Models.Mappers
{
    public class EnvironmentViewModelMapper : IViewModelMapper<Environment, EnvironmentReadModel>
    {

        public EnvironmentReadModel Map(Environment toMap)
        {
           return  new EnvironmentReadModel
            {
                Endpoints = (from ep in toMap.Endpoints
                             select ToEndpointViewModel(ep)).OrderBy(x=>x.Type).ThenBy(x=>x.Key).ToList(),
                environmentName = toMap.Name
            };
        }

        private EnvironmentReadModel.EndpointViewModel ToEndpointViewModel(ConfigurationItem toMap)
        {
            var result = new EnvironmentReadModel.EndpointViewModel
            {
                Key = toMap.Key,
                Value = toMap.Value,
                Type = toMap.TypeName,
                Description = toMap.Description
            };

            return result;
        }
    }
}