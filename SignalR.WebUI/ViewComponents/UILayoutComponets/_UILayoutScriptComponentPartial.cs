using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.UILayoutComponets
{
    public class _UILayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
