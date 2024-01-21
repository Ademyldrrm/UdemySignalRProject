using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.MenuComponents
{
    public class _MenuNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
