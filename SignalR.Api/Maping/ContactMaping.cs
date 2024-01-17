using AutoMapper;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Maping
{
    public class ContactMaping:Profile
    {
        public ContactMaping()
        {
                CreateMap<Contact,ResultContactDto>().ReverseMap();
                CreateMap<Contact,CreateContactDto>().ReverseMap();
                CreateMap<Contact,UpdateContactDto>().ReverseMap();
                CreateMap<Contact,GetContactDto>().ReverseMap();
        }
    }
}
