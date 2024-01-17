using AutoMapper;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Maping
{
    public class SocialMediaMaping:Profile
    {
        public SocialMediaMaping()
        {
                CreateMap<SocialMedia,ResultSocialMediaDto>().ReverseMap();
                CreateMap<SocialMedia,CreateSocialMediaDto>().ReverseMap();
                CreateMap<SocialMedia,UpdateSocialMediaDto>().ReverseMap();
                CreateMap<SocialMedia,GetSocialMedia>().ReverseMap();
        }
    }
}
