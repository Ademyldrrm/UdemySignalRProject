using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.SliderDtos;
using SignalR.EntityLayer.DAL.Entities;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

		public SlidersController(ISliderService sliderService, IMapper mapper)
		{
			_sliderService = sliderService;
			_mapper = mapper;
		}

		[HttpGet]
        public IActionResult Sliderlist()
        {
            var values=_sliderService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSlider(CrateSliderDto crateSliderDto)
        {
            _sliderService.TAdd(new Slider()
            {
                Description1 = crateSliderDto.Description1,
                Description2 = crateSliderDto.Description2,
                Description3 = crateSliderDto.Description3,
                Title1 = crateSliderDto.Title1,
                Title2 = crateSliderDto.Title2,
                Title3 = crateSliderDto.Title3,
                
            });
            return Ok("Öne çıkan alanı başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var values = _sliderService.TGetById(id);
            _sliderService.TDelete(values);
            return Ok("Sile işlemi Gerçekleşti");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            _sliderService.TUpdate(new Slider()
            {
                Description1 = updateSliderDto.Description1,
                Description2 = updateSliderDto.Description2,
                Description3 = updateSliderDto.Description3,
                Title1 = updateSliderDto.Title1,
                Title2 = updateSliderDto.Title2,
                Title3 = updateSliderDto.Title3,
                SliderID = updateSliderDto.SliderID,    
                 
            });
            return Ok("Güncelleme işlemi Gerçekleşti");
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(value);
        }
    }
}
