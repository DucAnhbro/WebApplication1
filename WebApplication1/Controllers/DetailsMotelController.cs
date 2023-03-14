using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DetailsMotelController : Controller
    {
        public DemodatbaseContext context = new DemodatbaseContext();

        public IActionResult Index(int id)
        {
           
            ViewBag.DetailMotels = deltails;
            return View();
        }
    }
}
