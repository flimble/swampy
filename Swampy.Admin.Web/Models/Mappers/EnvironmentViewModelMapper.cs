using System.Linq;
using Swampy.Admin.Web.Models.ReadModels;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.Models.Mappers
{
    public class EnvironmentViewModelMapper : IViewModelMapper<SwampyEnvironment, EnvironmentReadModel>
    {

        public EnvironmentReadModel Map(SwampyEnvironment toMap)
        {
           return  new EnvironmentReadModel
            {
                Endpoints = (from ep in toMap.ConfigurationItems
                             select ToEndpointViewModel(ep)).OrderBy(x=>x.Type).ThenBy(x=>x.Key).ToList(),
                environmentName = toMap.Name
            };
        }

        private EnvironmentReadModel.EndpointViewModel ToEndpointViewModel(ConfigurationItem toMap)
        {
            var result = new EnvironmentReadModel.EndpointViewModel
            {
                Key = toMap.Name,
                Value = toMap.Name,
                Type = toMap.TypeName,
                Description = toMap.Description
            };

            return result;
        }
    }
}