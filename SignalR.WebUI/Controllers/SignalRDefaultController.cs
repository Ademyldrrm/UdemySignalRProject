using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
