using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		[HttpGet]
		public IActionResult List()
		{
			return Ok(_notificationService.TGetListAll());
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}
		[HttpGet("GetAllNotificationFalse")]
		public IActionResult GetAllNotificationFalse()
		{
			return Ok(_notificationService.TGEtAllNotificationByFalse());
		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificatonDto createNotificatonDto)
		{
			Notification notification = new Notification()
			{
				Description = createNotificatonDto.Description,
				Icon = createNotificatonDto.Icon,
				Status = false,
				Type = createNotificatonDto.Type,
				Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
			};
			_notificationService.TAdd(notification);
			return Ok("Ekleme işlemi başarıyla yapıldı");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			_notificationService.TDelete(value);
			return Ok("Bildirim Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificatonDto updateNotificatonDto)
		{
			Notification notification = new Notification()
			{
				NotificationID = updateNotificatonDto.NotificationID,
				Description = updateNotificatonDto.Description,
				Icon = updateNotificatonDto.Icon,
				Status = updateNotificatonDto.Status,
				Type = updateNotificatonDto.Type,
				Date = updateNotificatonDto.Date
			};
			_notificationService.TUpdate(notification);
			return Ok("Güncelleme işlemi başarıyla yapıldı");
		}
		[HttpGet("NotificationChangeToFalse/{id}")]
		public IActionResult NotificationChangeToFalse(int id)
		{
			_notificationService.TNotificationChangeToFalse(id);
			return Ok("Güncelleme Yapıldı");
		}
        [HttpGet("NotificationChangeToTrue/{id}")]
        public IActionResult NotificationChangeToTrue(int id)
		{
			_notificationService.TNotificationChangeToTrue(id);
			return Ok("Güncelleme Yapıldı");
		}
    }
}
