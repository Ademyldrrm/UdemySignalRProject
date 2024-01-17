using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.DAL.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingsService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingsService, IMapper mapper)
        {
            _bookingsService = bookingsService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingsService.TGetListAll());
            return Ok(values);  
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            _bookingsService.TAdd(new Booking()
            {
                Date = createBookingDto.Date,
                Mail = createBookingDto.Mail,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
                
            });
            return Ok("Ekleme Başarılı bir şekilde gerçekleşti");
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var values=_bookingsService.TGetById(id);
            _bookingsService.TDelete(values);
            return Ok("Silme işlemi Başarılı bir şekilde gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            _bookingsService.TUpdate(new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
                Date = updateBookingDto.Date,
            });
            return Ok("Güncelleme işlemi Gerçekleşti");

        }
        [HttpGet("Getbooking")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingsService.TGetById(id);
            return Ok(value);
               
        }
    }
}
