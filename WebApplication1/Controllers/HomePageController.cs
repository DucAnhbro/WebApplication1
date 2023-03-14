
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomePageController : Controller
    {
        public DemodatbaseContext context = new DemodatbaseContext();
        public IActionResult HomePage()
        {
            var MotelList = (from m in context.Motels
                            select m).ToList();
            ViewBag.Motels = MotelList;
            return View();
        }
    }
}
