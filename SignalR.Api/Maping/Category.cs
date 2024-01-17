using AutoMapper;
using SignalR.DtoLayer.CategoryDto;

namespace SignalR.Api.Maping
{
    public class Category:Profile
    {
        public Category()
        {
                CreateMap<Category,ResultCategoryDto>().ReverseMap();
                CreateMap<Category,CreateCategoryDto>().ReverseMap();
                CreateMap<Category,UpdateCategoryDto>().ReverseMap();
                CreateMap<Category,GetCategoryDto>().ReverseMap();
               
        }
    }
}
