using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;

namespace Proyect_RaceTrack.Controllers
{
    public class CocheraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CocheraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cochera
        public async Task<IActionResult> Index()
        {
              return _context.Cochera != null ? 
                          View(await _context.Cochera.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cochera'  is null.");
        }

        // GET: Cochera/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cochera == null)
            {
                return NotFound();
            }

            var cochera = await _context.Cochera
                .FirstOrDefaultAsync(m => m.CocheraId == id);
            if (cochera == null)
            {
                return NotFound();
            }

            return View(cochera);
        }

        // GET: Cochera/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cochera/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CocheraId,CocheraNombre,CocheraNumero,CocheraSector,CocheraAptoMantenimiento,CocheraOficinas")] Cochera cochera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cochera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cochera);
        }

        // GET: Cochera/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cochera == null)
            {
                return NotFound();
            }

            var cochera = await _context.Cochera.FindAsync(id);
            if (cochera == null)
            {
                return NotFound();
            }
            return View(cochera);
        }

        // POST: Cochera/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CocheraId,CocheraNombre,CocheraNumero,CocheraSector,CocheraAptoMantenimiento,CocheraOficinas")] Cochera cochera)
        {
            if (id != cochera.CocheraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cochera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocheraExists(cochera.CocheraId))
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
            return View(cochera);
        }

        // GET: Cochera/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cochera == null)
            {
                return NotFound();
            }

            var cochera = await _context.Cochera
                .FirstOrDefaultAsync(m => m.CocheraId == id);
            if (cochera == null)
            {
                return NotFound();
            }

            return View(cochera);
        }

        // POST: Cochera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cochera == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cochera'  is null.");
            }
            var cochera = await _context.Cochera.FindAsync(id);
            if (cochera != null)
            {
                _context.Cochera.Remove(cochera);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CocheraExists(int id)
        {
          return (_context.Cochera?.Any(e => e.CocheraId == id)).GetValueOrDefault();
        }
    }
}
