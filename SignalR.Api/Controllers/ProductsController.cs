using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.DAL.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetProductlist()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }
        [HttpGet("ProductListWith")]
        public IActionResult GetProductListWith()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                CategoryName = y.Category.CategoryName,
                ProductName = y.ProductName,
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductID = y.ProductID,
                ProductStatus = y.ProductStatus,
            });
            return Ok(values.ToList());
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
               ImageUrl = createProductDto.ImageUrl,
               Description = createProductDto.Description,
               Price = createProductDto.Price,
               ProductName = createProductDto.ProductName,
               ProductStatus = createProductDto.ProductStatus,
            });
            return Ok("Ürün başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetById(id);
            _productService.TDelete(values);
            return Ok("Sile işlemi Gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
                ImageUrl = updateProductDto.ImageUrl,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                ProductName = updateProductDto.ProductName,
                ProductStatus = updateProductDto.ProductStatus,
                ProductID=updateProductDto.ProductID
            });
            return Ok("Güncelleme işlemi Gerçekleşti");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

    }
}
