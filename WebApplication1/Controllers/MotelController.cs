using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MotelController : Controller
    {
        public DemodatbaseContext context = new DemodatbaseContext();
        public async Task<IActionResult> Index()
        {
            return View(await context.Motels.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.Motels == null)
            {
                return NotFound();
            }

            var motel = await context.Motels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motel == null)
            {
                return NotFound();
            }

            return View(motel);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MotelName,Address,TotalRoom,HostPhone,CustomerId")] Motel motel)
        {
            if (ModelState.IsValid)
            {
                context.Add(motel);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motel);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Motels == null)
            {
                return NotFound();
            }

            var motel = await context.Motels.FindAsync(id);
            if (motel == null)
            {
                return NotFound();
            }
            return View(motel);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MotelName,Address,TotalRoom,HostPhone,CustomerId")] Motel motel)
        {
            if (id != motel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(motel);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotelExists(motel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(motel);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Motels == null)
            {
                return NotFound();
            }

            var motel = await context.Motels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motel == null)
            {
                return NotFound();
            }

            return View(motel);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (context.Motels == null)
            {
                return Problem("Entity set 'DemodatbaseContext.Customers'  is null.");
            }
            var motel = await context.Motels.FindAsync(id);
            if (motel != null)
            {
                context.Motels.Remove(motel);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotelExists(int id)
        {
            return context.Motels.Any(e => e.Id == id);
        }
    }
}
