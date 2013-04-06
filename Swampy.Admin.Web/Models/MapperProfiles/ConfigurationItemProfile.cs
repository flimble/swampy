using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.Models.Mappers
{
    public class ConfigurationItemProfile : Profile
    {

        protected override void Configure()
        {
            Mapper.CreateMap<ConfigurationItem, ConfigurationItemInputModel>();


            Mapper.CreateMap<ConfigurationItemInputModel, ConfigurationItem>()
                  .ForMember(dest => dest.StoreAsToken, opt => opt.Ignore())
                  .ForMember(dest => dest.HydratedValue, opt => opt.Ignore())
                  .ForMember(dest => dest.SwampyEnvironment, opt => opt.Ignore())
                  .ForMember(dest => dest.ConfigurationType, opt => opt.Ignore())
                  .ForMember(dest => dest.Description, opt => opt.Ignore())
                  .ForMember(dest => dest.ModificationDetails, opt => opt.Ignore());

        }
    }
}