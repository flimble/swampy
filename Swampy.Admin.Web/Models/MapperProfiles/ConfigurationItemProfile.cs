﻿using System;
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
            Mapper.CreateMap<ConfigurationItem, ConfigurationItemInputModel>()
                  .ForMember(x => x.EnvironmentId, opt => opt.MapFrom(x => x.SwampyEnvironment.Id))
                  .ForMember(x => x.SelectedItemType, opt => opt.MapFrom(src => src.ConfigurationType))
                  .ForMember(x => x.ActualValue, opt => opt.MapFrom(src => src.HydratedValue))
                  .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                  .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                  .ForMember(x => x.Value, opt => opt.MapFrom(src=>src.Value));


            Mapper.CreateMap<ConfigurationItemInputModel, ConfigurationItem>()
                  .ForMember(dest => dest.ConfigurationType, opt => opt.MapFrom(x=>x.SelectedItemType))
                  .ForMember(dest => dest.StoreAsToken, opt => opt.Ignore())
                  .ForMember(dest => dest.HydratedValue, opt => opt.Ignore())
                  .ForMember(dest => dest.SwampyEnvironment, opt => opt.Ignore())
                  
                  .ForMember(dest => dest.Description, opt => opt.Ignore())
                  .ForMember(dest => dest.ModificationDetails, opt => opt.Ignore());

        }
    }
}