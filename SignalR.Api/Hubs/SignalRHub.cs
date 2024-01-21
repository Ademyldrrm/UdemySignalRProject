using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalR.Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
		public SignalRHub(ICategoryService categoryService, IProductService productService)
		{
			_categoryService = categoryService;
			_productService = productService;
		}

		public async Task SendStatistic()
		{
			var value = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiverCategoryCount", value);

			var value2 = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiverProductCount", value2);

			var value3 = _categoryService.TActiveCategoryCount();
			var value4 = _categoryService.TPasivefCategoryCount();
			await Clients.All.SendAsync("ReceiverActiveCategoryCount", value3);
			await Clients.All.SendAsync("ReceiverPasiveCategoryCount", value4);

		}

	}
}
