using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Swampy.Admin.Web.Models.Operation;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.Models.Mappers
{
    public class SwampyEnvironmentProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<SwampyEnvironment, EnvironmentReadModel>()
                  .ForMember(x => x.ConfigurationItems, opt => opt.MapFrom(src => src.ConfigurationItems));

            Mapper.CreateMap<SwampyEnvironment, EnvironmentInputModel>();

            Mapper.CreateMap<EnvironmentInputModel, SwampyEnvironment>()
                  .ForMember(dest => dest.ConfigurationItems, opt => opt.MapFrom(src => src.ConfigurationItems))
                  .ForMember(dest => dest.Fake, opt => opt.Ignore())
                  .ForMember(dest => dest.ModificationDetails, opt => opt.Ignore());
        }
    }
}