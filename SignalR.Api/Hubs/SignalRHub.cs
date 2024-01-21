using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalR.Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
		private readonly IOrderService _orderService;
        private readonly IMoneyCasesService _moneyCasesService;
        private readonly IMenuTableService _menuTableService;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCasesService moneyCasesService, IMenuTableService menuTableService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCasesService = moneyCasesService;
            _menuTableService = menuTableService;
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

			var value5 = _productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiverProductCountByCategoryNameHamburger", value5);

			var value6 = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiverProductCountByCategoryNameDrink", value6);

			var value7 =_productService.TProductPriceAvg();
			await Clients.All.SendAsync("ProductPriveAvg", value7.ToString("0.00") + "₺");

            var value8 = _productService.TProductNameMaxPrice();
            await Clients.All.SendAsync("ReceiverProductNameMaxPrice", value8);

            var value9 = _productService.TProductNameMinPrice();
            await Clients.All.SendAsync("ReceiverProductNameMinPrice", value9);

            var value10 = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiverProductAvgPriceByHamburger", value10.ToString("0.00") + "₺");

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiverTotalOrderCount", value11);

            var value12 = _orderService.TTotalOrderActiveCount();
            await Clients.All.SendAsync("ReceiverTotalOrderActiveCount", value12);

            var value13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiverLastOrderPrice", value13.ToString("0.00") + "₺");

            var value14 = _moneyCasesService.TTotalMoneyCasesAmount();
            await Clients.All.SendAsync("ReceiverTotalMoneyCasesAmount", value14.ToString("0.00") + "₺");

            var value15 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiverMenuTableCount", value15);

        }
		public async Task SendProgress()
        {
			var value = _moneyCasesService.TTotalMoneyCasesAmount();
			await Clients.All.SendAsync("ReceiverTotalMoneyCasesAmount", value.ToString("0.00") + "₺");
		}
	}
}
