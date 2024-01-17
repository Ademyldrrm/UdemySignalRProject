using AutoMapper;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.DAL.Entities;

namespace SignalR.Api.Maping
{
    public class ProductMaping:Profile
    {
        public ProductMaping()
        {
                CreateMap<Product,ResultProductDto>().ReverseMap(); 
                CreateMap<Product,CreateProductDto>().ReverseMap(); 
                CreateMap<Product,UpdateProductDto>().ReverseMap(); 
                CreateMap<Product,GetProductDto>().ReverseMap(); 
        }
    }
}
