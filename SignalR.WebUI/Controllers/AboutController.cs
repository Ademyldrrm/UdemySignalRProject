using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WebUI.Dtos.AboutDtos;

namespace SignalR.WebUI.Controllers
{
	public class AboutController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AboutController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessagae = await client.GetAsync("https://localhost:7109/api/Abouts");
			if (responseMessagae.IsSuccessStatusCode)
			{
				var jsonData = await responseMessagae.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
