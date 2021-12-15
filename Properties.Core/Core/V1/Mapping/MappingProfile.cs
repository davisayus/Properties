using AutoMapper;
using Properties.Entities.Dtos;
using Properties.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Core.Core.V1.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Property, PropertyDto>();
            CreateMap<PropertyDto, Property>();

            CreateMap<Property, PropertyCreateDto>();
            CreateMap<PropertyCreateDto, Property>()
                .ForMember(p=> p.MainImage, opt=> opt.MapFrom(pc=>pc.MainImage.FileName));

            CreateMap<PropertyCreateDto, PropertyDto>();
            CreateMap<PropertyDto, PropertyCreateDto>();

            CreateMap<PropertyImage, PropertyImageCreateDto>();
            CreateMap<PropertyImageCreateDto, PropertyImage>();

            CreateMap<PropertyImage, PropertyImageDto>();
            CreateMap<PropertyImageDto, PropertyImage>();

        }
    }
}
