using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
