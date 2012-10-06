using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAIG.PS.Swampy.Service.Entities.Endpoint;
using Environment = SAIG.PS.Swampy.Service.Entities.Environment;

namespace SAIG.PS.Swampy.Admin.MVC.Models.Mappers
{
    public class EnvironmentViewModelMapper : IViewModelMapper<Environment, EnvironmentViewModel>
    {

        public EnvironmentViewModel Map(Environment toMap)
        {
           return  new EnvironmentViewModel
            {
                Endpoints = (from ep in toMap.Endpoints
                             select ToEndpointViewModel(ep)).ToList(),
                environmentName = toMap.Name
            };
        }

        private EnvironmentViewModel.EndpointViewModel ToEndpointViewModel(EndpointBase toMap)
        {
            var result = new EnvironmentViewModel.EndpointViewModel
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