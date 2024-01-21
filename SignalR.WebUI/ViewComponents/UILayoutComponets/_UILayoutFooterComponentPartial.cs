using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.UILayoutComponets
{
    public class _UILayoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
