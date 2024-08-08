using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EfCoreApp.Models.Data;

namespace EfCoreApp.Controllers
{
    public class OgretmenController : Controller
    {
        private readonly DataContext _context;

        public OgretmenController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ogretmenler = await _context.Ogretmenler.ToListAsync();
            return View(ogretmenler);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogretmen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ogretmen);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler.FindAsync(id);

            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ogretmen ogretmen)
        {
            if (id != ogretmen.OgretmenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogretmen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgretmenExists(ogretmen.OgretmenId))
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
            return View(ogretmen);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler
                                        .FirstOrDefaultAsync(o => o.OgretmenId == id);

            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen == null)
            {
                return NotFound();
            }
            _context.Ogretmenler.Remove(ogretmen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgretmenExists(int id)
        {
            return _context.Ogretmenler.Any(e => e.OgretmenId == id);
        }
    }
}
