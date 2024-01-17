using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class _AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
