using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.UILayoutComponets
{
    public class _UILayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
