using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.DAL.Entities;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountsController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetDiscountlist()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount()
            {
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                ImageUrl = createDiscountDto.ImageUrl,
                Title = createDiscountDto.Title,
                Status = false
            }) ;
            return Ok("İndirim başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var values = _discountService.TGetById(id);
            _discountService.TDelete(values);
            return Ok("Sile işlemi Gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                ImageUrl = updateDiscountDto.ImageUrl,
                Title = updateDiscountDto.Title,
                DiscountID = updateDiscountDto.DiscountID,
                Status = false
            }); 
            return Ok("Güncelleme işlemi Gerçekleşti");
        }
		[HttpGet("ChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChanfeStatusToTrue(id);
            return Ok("Ürün indirimi aktif hale getirildi");
        }
        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChanfeStatusToFalse(id);
            return Ok("Ürün indirimi pasif hale getirildi");
        }
        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {
            return Ok(_discountService.TGetListByStatusTrue());
        }

        
    }
}

