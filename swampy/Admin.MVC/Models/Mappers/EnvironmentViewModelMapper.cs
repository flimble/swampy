﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Swampy.Service.Entities.Endpoint;
using Environment = Swampy.Service.Entities.Environment;

namespace Swampy.Admin.MVC.Models.Mappers
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