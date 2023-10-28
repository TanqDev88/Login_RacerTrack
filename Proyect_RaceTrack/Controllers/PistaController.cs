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
    public class PistaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PistaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pista
        public async Task<IActionResult> Index()
        {
              return _context.Pista != null ? 
                          View(await _context.Pista.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Pista'  is null.");
        }

        // GET: Pista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pista == null)
            {
                return NotFound();
            }

            var pista = await _context.Pista
                .FirstOrDefaultAsync(m => m.PistaId == id);
            if (pista == null)
            {
                return NotFound();
            }

            return View(pista);
        }

        // GET: Pista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PistaId,PistaNombre,PistaCodigo,PistaMaterial,PistaIluminacion,PistaAprovisionamiento")] Pista pista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pista);
        }

        // GET: Pista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pista == null)
            {
                return NotFound();
            }

            var pista = await _context.Pista.FindAsync(id);
            if (pista == null)
            {
                return NotFound();
            }
            return View(pista);
        }

        // POST: Pista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PistaId,PistaNombre,PistaCodigo,PistaMaterial,PistaIluminacion,PistaAprovisionamiento")] Pista pista)
        {
            if (id != pista.PistaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PistaExists(pista.PistaId))
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
            return View(pista);
        }

        // GET: Pista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pista == null)
            {
                return NotFound();
            }

            var pista = await _context.Pista
                .FirstOrDefaultAsync(m => m.PistaId == id);
            if (pista == null)
            {
                return NotFound();
            }

            return View(pista);
        }

        // POST: Pista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pista == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pista'  is null.");
            }
            var pista = await _context.Pista.FindAsync(id);
            if (pista != null)
            {
                _context.Pista.Remove(pista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PistaExists(int id)
        {
          return (_context.Pista?.Any(e => e.PistaId == id)).GetValueOrDefault();
        }
    }
}
