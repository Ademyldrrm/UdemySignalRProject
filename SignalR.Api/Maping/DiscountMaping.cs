using AutoMapper;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.DAL.Entities;

namespace SignalR.Api.Maping
{
    public class DiscountMaping:Profile
    {
        public DiscountMaping()
        {
                CreateMap<Discount,ResultDiscountDto>().ReverseMap();
                CreateMap<Discount,CreateDiscountDto>().ReverseMap();
                CreateMap<Discount,UpdateDiscountDto>().ReverseMap();
                CreateMap<Discount,GetDiscountDto>().ReverseMap();
        }
    }
}
