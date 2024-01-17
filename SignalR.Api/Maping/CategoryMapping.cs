using AutoMapper;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.DAL.Entities;

namespace SignalR.Api.Maping
{
	public class CategoryMapping:Profile
	{
        public CategoryMapping()
        {
			CreateMap<Category, ResultCategoryDto>().ReverseMap();
			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();
			CreateMap<Category, GetCategoryDto>().ReverseMap();
		}
    }
}
