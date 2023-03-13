
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
