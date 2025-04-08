using Microsoft.AspNetCore.Mvc;

namespace Webss.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
