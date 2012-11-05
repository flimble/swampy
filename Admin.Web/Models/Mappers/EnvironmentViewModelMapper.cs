using System.Linq;
using Swampy.Admin.Web.Models.ReadModels;
using Swampy.Domain.Entities.Endpoint;
using Environment = Swampy.Domain.Entities.Environment;

namespace Swampy.Admin.Web.Models.Mappers
{
    public class EnvironmentViewModelMapper : IViewModelMapper<Environment, EnvironmentReadModel>
    {

        public EnvironmentReadModel Map(Environment toMap)
        {
           return  new EnvironmentReadModel
            {
                Endpoints = (from ep in toMap.Endpoints
                             select ToEndpointViewModel(ep)).ToList(),
                environmentName = toMap.Name
            };
        }

        private EnvironmentReadModel.EndpointViewModel ToEndpointViewModel(EndpointBase toMap)
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