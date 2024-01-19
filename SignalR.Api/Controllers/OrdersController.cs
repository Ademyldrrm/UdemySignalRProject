using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}
		[HttpGet("TotalOrderCount")]
		public IActionResult TotalOrderCount()
		{
			return Ok(_orderService.TTotalOrderCount());
		}
		[HttpGet("TotalOrderActiveCount")]
		public IActionResult TotalOrderActiveCount()
		{
			return Ok(_orderService.TTotalOrderActiveCount());
		}
		[HttpGet("TotalOrderPasiveCount")]
		public IActionResult TotalOrderPasiveCount()
		{
			return Ok(_orderService.TTotalOrderPasiveCount());
		}
		[HttpGet("LastOrderPrice")]
		public IActionResult LastOrderPrice()
		{
			return Ok(_orderService.TLastOrderPrice());
		}
		[HttpGet("TodayTotalPrice")]
		public IActionResult TodayTotalPrice()
		{
			return Ok(_orderService.TTodayTotalPrice());
		}
	}
}
