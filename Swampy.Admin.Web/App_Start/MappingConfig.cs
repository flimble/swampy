using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Swampy.Admin.Web.Models;
using Swampy.Admin.Web.Models.Mappers;
using Swampy.Admin.Web.Models.Operation;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.App_Start
{
    public static class MappingConfig
    {
        /// <summary>
        /// Configure Automapper configuration by adding all profile classes
        /// Profiles are split by entity
        /// </summary>
        public static void Configure()
        {            
            Mapper.AddProfile(new SwampyEnvironmentProfile());
            Mapper.AddProfile(new ConfigurationItemProfile());
        }
    }
}