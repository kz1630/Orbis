using Microsoft.AspNetCore.Mvc;

namespace Orbis.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
