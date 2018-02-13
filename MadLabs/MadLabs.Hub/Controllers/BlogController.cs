using Microsoft.AspNetCore.Mvc;

namespace MadLabs.Hub.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}