using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.DAL.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCategorylist() 
        {
			var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
			return Ok(values);
		}
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryService.TAdd(new Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                Status = createCategoryDto.Status,
            });
            return Ok("Kategori başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var values=_categoryService.TGetById(id);
            _categoryService.TDelete(values);
            return Ok("Sile işlemi Gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryID = updateCategoryDto.CategoryID,
                Status = updateCategoryDto.Status,
                CategoryName = updateCategoryDto.CategoryName
            });
            return Ok("Güncelleme işlemi Gerçekleşti");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value=_categoryService.TGetById(id);
            return Ok(value);
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
        }
		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			return Ok(_categoryService.TActiveCategoryCount());
		}
		[HttpGet("PasiveCategoryCount")]
		public IActionResult PasiveCategoryCount()
		{
			return Ok(_categoryService.TPasivefCategoryCount());
		}


	}
}
