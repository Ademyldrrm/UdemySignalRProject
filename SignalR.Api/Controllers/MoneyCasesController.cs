using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCasesController : ControllerBase
	{
		private readonly IMoneyCasesService _moneyCasesService;

		public MoneyCasesController(IMoneyCasesService moneyCasesService)
		{
			_moneyCasesService = moneyCasesService;
		}
		[HttpGet("MoneyCasesTotal")]
		public IActionResult MoneyCasesTotal()
		{
			return Ok(_moneyCasesService.TTotalMoneyCasesAmount());
		}
	}
}
