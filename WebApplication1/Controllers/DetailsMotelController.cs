using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DetailsMotelController : Controller
    {
        public DemodatbaseContext context = new DemodatbaseContext();
        public DetailMotel motel = new DetailMotel();
        public IActionResult Index(int id)
        {
            var details = context.DetailMotels.FirstOrDefault(x=> x.Id == id);
            motel.AreaOfRoom = details.AreaOfRoom;
            motel.Status = details.Status;
            motel.Price = details.Price;
            return View(motel);
        }
    }
}
