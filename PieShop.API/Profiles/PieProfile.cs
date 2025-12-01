
using AutoMapper;
using PieShop.API.Entities;
using PieShop.API.Models;

namespace PieShop.API.Profiles
{
    public class PieProfile : Profile
    {
        public PieProfile()
        {
            CreateMap<Pie, PieDto>()
                .ForMember(dest => dest.PieName, (options) => options.MapFrom(source => source.Name))
                .ForMember(dest => dest.Description, (options) => options.MapFrom(source => source.Description))
                .ReverseMap();
        }
    }
}

