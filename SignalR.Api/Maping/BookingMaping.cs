using AutoMapper;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.DAL.Entities;

namespace SignalR.Api.Maping
{
    public class BookingMaping:Profile
    {
        public BookingMaping()
        {
                CreateMap<Booking,ResultBookingDto>().ReverseMap();
                CreateMap<Booking,CreateBookingDto>().ReverseMap();
                CreateMap<Booking,UpdateBookingDto>().ReverseMap();
                CreateMap<Booking,GetBookingDto>().ReverseMap();
        }
    }
}
