using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.Models.MapperProfiles
{
    public class ConfigurationItemCloneProfile : Profile
    {

        protected override void Configure()
        {
            Mapper.CreateMap<ConfigurationItem, ConfigurationItem>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}