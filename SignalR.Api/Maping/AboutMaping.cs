using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.DAL.Entities;

namespace SignalR.Api.Maping
{
    public class AboutMaping:Profile
    {
        public AboutMaping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto >().ReverseMap();
            CreateMap<About, GetAboutDto >().ReverseMap();
        }
    }
}
