using AutoMapper;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.DAL.Entities;

namespace SignalR.Api.Maping
{
    public class FeatureMaping:Profile
    {
        public FeatureMaping()
        {
                CreateMap<Feature,ResultFeatureDto>().ReverseMap();
                CreateMap<Feature,CreateFeatureDto>().ReverseMap();
                CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
                CreateMap<Feature,GetFeatureDto>().ReverseMap();
        }
    }
}
