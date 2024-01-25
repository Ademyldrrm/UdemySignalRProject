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
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCasesService moneyCasesService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCasesService = moneyCasesService;
			_menuTableService = menuTableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}
		public static int clientCount { get; set; } = 0;
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
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00") + "₺");

            var value2 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTActiveOrderCount", value2);

            var value3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value3);

			var value5 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value5);

            var value6 = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveAvgPriceByHamburger", value6);

            var value7 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value7);

            var value8 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value8);


        }
		public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiverBookingList", values);
        }


		public async Task SendNotification()
		{
			var value = _notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

			var notificationListByFalse = _notificationService.TGEtAllNotificationByFalse();
			await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);
		}
		public async Task GetMenuTableStatus()
		{
			var value = _menuTableService.TGetListAll();
			await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
		}
		public async Task SendMessage(string user,string message)
		{
			await Clients.All.SendAsync("ReceiverMessage", user, message);
		}
        public override async Task OnConnectedAsync()
        {
           clientCount++;
			await Clients.All.SendAsync("ReceiverClientCount", clientCount);
			await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
			clientCount--;
			await Clients.All.SendAsync("ReceiverClientCount",clientCount);
			await base.OnDisconnectedAsync(exception);
        }

    }
}
