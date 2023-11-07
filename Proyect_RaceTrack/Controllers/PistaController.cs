using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;
using Proyect_RaceTrack.ViewModels.PistaViewModels;
using Proyect_RaceTrack.Services;
using Proyect_RaceTrack.ViewModels;

namespace Proyect_RaceTrack.Controllers
{
    public class PistaController : Controller
    {
        private IPistaService _pistaService;
        private ICocheraService _cocheraService;
        public PistaController(IPistaService pistaService, ICocheraService cocheraService)
        {
            _pistaService = pistaService;
            _cocheraService = cocheraService;
        }
        // GET: Pista
        public IActionResult Index(string nameFilterPista, [Bind("PistaId,PistaNombre,PistaCodigo,PistaMaterial,PistaIluminacion,PistaAprovisionamiento")] PistaIndexViewModel pistaView)
        {
            var model = new PistaIndexViewModel();
            model.pistas = _pistaService.GetAll(nameFilterPista);

            return View(model);
        }

        // GET: Pista/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pista = _pistaService.GetById(id.Value);
            // .FirstOrDefaultAsync(m => m.AeronaveId == id);
            if (pista == null)
            {
                return NotFound();
            }

            var viewModel = new PistaDetailViewModel();
            viewModel.PistaId = pista.PistaId;
            viewModel.PistaNombre = pista.PistaNombre;
            viewModel.PistaCodigo = pista.PistaCodigo;
            viewModel.PistaMaterial = pista.PistaMaterial;
            viewModel.PistaIluminacion = pista.PistaIluminacion;
            viewModel.PistaAprovisionamiento = pista.PistaAprovisionamiento;
            //viewModel.Hangars = await _context.Hangar.ToListAsync(); lo sugirio el IDE considerar
            viewModel.Cocheras = pista.Cocheras;
            //viewModel.CocheraNombre = pista.CocheraNombre; 

            ViewData["Cocheras"] = new SelectList(_cocheraService.GetAll(), "CocheraId", "CocheraNombre", "nameFilterCoch");
            ViewData["Cocheras"] = new SelectList(_cocheraService.GetAll(), "CocheraId", "CocheraNombre", "nameFilterCoch");
            return View(viewModel);
        }

        // GET: Pista/Create
        public IActionResult Create()
        {
            ViewData["Cocheras"] = new SelectList(_cocheraService.GetAll(), "CocheraId", "CocheraNombre", "nameFilterCoch");
            return View();
        }

        // POST: Pista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create([Bind("PistaId,PistaNombre,PistaCodigo,PistaMaterial,PistaIluminacion,PistaAprovisionamiento,CocheraIds")] PistaCreateViewModel pistaView)
        {
            //ModelState.Remove("Hangars"); No olvidar borrar esta validacion al realizar la relacion MaM
            if (ModelState.IsValid)
            {
                // var hangars = _context.Hangar.Where(x=> pistaView.HangarIds.Contains(x.HangarId)).ToList();

                var pista = new Pista
                {
                    PistaNombre = pistaView.PistaNombre,
                    PistaCodigo = pistaView.PistaCodigo,
                    PistaMaterial = pistaView.PistaMaterial,
                    PistaIluminacion = pistaView.PistaIluminacion,
                    PistaAprovisionamiento = pistaView.PistaAprovisionamiento,
                    //Cocheras = pistaView.CocheraIds;
                    // Hangars = hangars
                };

                _pistaService.Create(pista);
                return RedirectToAction(nameof(Index));
            }
            return View(pistaView);
        }

        // GET: Pista/Edit/5

        // public IActionResult Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var pista = _pistaService.GetById(id.Value);
        //     if (pista == null)
        //     {
        //         return NotFound();
        //     }
        //     var viewModel = new PistaEditViewModel();
        //     viewModel.PistaId = pista.PistaId;
        //     viewModel.PistaNombre = pista.PistaNombre;
        //     viewModel.PistaCodigo = pista.PistaCodigo;
        //     viewModel.PistaMaterial = pista.PistaMaterial;
        //     viewModel.PistaIluminacion = pista.PistaIluminacion;
        //     viewModel.PistaAprovisionamiento = pista.PistaAprovisionamiento;
        //     //viewModel.Hangars = pista.Hangars;
        //     // viewModel.HangarIds = pista.HangarsIds;
        //     // viewModel.Hangars = await _context.Hangar.ToListAsync(); lo sugirio el IDE considerar

        //     //ViewData["Hangars"] = new SelectList(_hangarService.GetAll(), "HangarId", "HangarNombre", "NameFilterCoc");
        //     return View(viewModel);
        // }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pista = _pistaService.GetById(id.Value);
            ViewData["CocheraId"] = new SelectList(_cocheraService.GetAll(), "CocheraId", "VehiculoTipo", "nameFilter");
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
        public IActionResult Edit(int id, [Bind("PistaId,PistaNombre,PistaCodigo,PistaMaterial,PistaIluminacion,PistaAprovisionamiento,CocheraIds")] Pista pista)
        {
            if (id != pista.PistaId)
            {
                return NotFound();
            }
            //ModelState.Remove("Locales");
            //ModelState.Remove("Talles");
            if (ModelState.IsValid)
            {
                try
                {
                    _pistaService.Update(pista);
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pista = _pistaService.GetById(id.Value);
            if (pista == null)
            {
                return NotFound();
            }

            var viewModel = new PistaDeleteViewModel();
            viewModel.PistaId = pista.PistaId;
            viewModel.PistaNombre = pista.PistaNombre;
            viewModel.PistaCodigo = pista.PistaCodigo;
            viewModel.PistaMaterial = pista.PistaMaterial;
            viewModel.PistaIluminacion = pista.PistaIluminacion;
            viewModel.PistaAprovisionamiento = pista.PistaAprovisionamiento;
            // viewModel.Hangars = await _context.Hangar.ToListAsync(); lo sugirio el IDE considerar

            return View(viewModel);
        }

        // POST: Pista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var aeronave = _pistaService.GetById(id);
            if (aeronave != null)
            {
                _pistaService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PistaExists(int id)
        {
            return _pistaService.GetById(id) != null;
        }
    }
}
