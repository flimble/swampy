using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Swampy.Admin.Web.Models.Operation;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.App_Start
{
    public static class MappingConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<SwampyEnvironment, EnvironmentRead>();

            Mapper.CreateMap<SwampyEnvironment, EnvironmentInput>();

            Mapper.CreateMap<EnvironmentInput, SwampyEnvironment>()
                  .ForMember(dest => dest.Fake, opt => opt.Ignore())
                  .ForMember(dest => dest.ConfigurationItems, opt => opt.Ignore())
                  .ForMember(dest => dest.Servers, opt => opt.Ignore())
                  .ForMember(dest => dest.ModificationDetails, opt => opt.Ignore());

                  
        }
    }
}