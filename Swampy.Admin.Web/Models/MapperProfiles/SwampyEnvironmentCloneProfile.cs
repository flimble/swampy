using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.Models.MapperProfiles
{
    public class SwampyEnvironmentCloneProfile : Profile
    {

        protected override void Configure()
        {
            Mapper.CreateMap<SwampyEnvironment, SwampyEnvironment>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}