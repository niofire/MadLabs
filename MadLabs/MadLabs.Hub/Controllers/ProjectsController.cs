using Microsoft.AspNetCore.Mvc;

namespace MadLabs.Hub.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}