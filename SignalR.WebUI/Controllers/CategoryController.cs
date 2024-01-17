using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WebUI.Dtos.CategoryDtos;
using SignalR.WebUI.Dtos.ContactDtos;
using System.Text;

namespace SignalR.WebUI.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessagae = await client.GetAsync("https://localhost:7109/api/Categories");
			if (responseMessagae.IsSuccessStatusCode)
			{
				var jsonData = await responseMessagae.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCategoryDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7109/api/Categories", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessagae = await client.DeleteAsync($"https://localhost:7109/api/Categories/{id}");
			if (responseMessagae.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateCategory(int id)
		{
			var clinent = _httpClientFactory.CreateClient();
			var responseMessage=await clinent.GetAsync($"https://localhost:7109/api/Categories/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var clinent = _httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(updateCategoryDto);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await clinent.PutAsync("https://localhost:7109/api/Categories/", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
