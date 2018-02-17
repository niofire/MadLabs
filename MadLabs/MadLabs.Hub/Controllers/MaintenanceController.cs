using Microsoft.AspNetCore.Mvc;

namespace MadLabs.Hub.Controllers
{
    public class MaintenanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}