using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.UILayoutComponets
{
	public class _UILayoutHeadComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
