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
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Administrador, Jefe de pista")]
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
            if (pista == null)
            {
                return NotFound();
            }

            return View(pista);
        }

        // GET: Pista/Create
        public IActionResult Create()
        {
            ViewData["Cocheras"] = new SelectList(_cocheraService.GetAll(), "CocheraId", "CocheraNombre", "nameFilterCoch");
            return View();
        }

        // POST: Pista/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create([Bind("PistaId,PistaNombre,PistaCodigo,PistaMaterial,PistaIluminacion,PistaAprovisionamiento,CocheraIds")] PistaCreateViewModel pistaView)
        {
            if (ModelState.IsValid)
            {
                var cocheras = _cocheraService.GetAll().Where(x => pistaView.CocheraIds.Contains(x.CocheraId)).ToList();
                var pista = new Pista
                {
                    PistaNombre = pistaView.PistaNombre,
                    PistaCodigo = pistaView.PistaCodigo,
                    PistaMaterial = pistaView.PistaMaterial,
                    PistaIluminacion = pistaView.PistaIluminacion,
                    PistaAprovisionamiento = pistaView.PistaAprovisionamiento,
                    Cocheras = cocheras
                };

                _pistaService.Create(pista);
                return RedirectToAction(nameof(Index));
            }
            return View(pistaView);
        }

        // GET: Pista/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pista = _pistaService.GetById(id.Value);
            ViewData["Cocheras"] = new SelectList(_cocheraService.GetAll(), "CocheraId", "CocheraNombre");

            if (pista == null)
            {
                return NotFound();
            }

            var viewModel = new PistaEditViewModel();
            viewModel.PistaId = pista.PistaId;
            viewModel.PistaNombre = pista.PistaNombre;
            viewModel.PistaCodigo = pista.PistaCodigo;
            viewModel.PistaMaterial = pista.PistaMaterial;
            viewModel.PistaIluminacion = pista.PistaIluminacion;
            viewModel.PistaAprovisionamiento = pista.PistaAprovisionamiento;
            viewModel.CocheraIds = pista.Cocheras.Select(c => c.CocheraId).ToList();
            return View(viewModel);
        }

        // POST: Pista/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PistaId,PistaNombre,PistaCodigo,PistaMaterial,PistaIluminacion,PistaAprovisionamiento,CocheraIds")] PistaEditViewModel pistaView)
        {
            if (id != pistaView.PistaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var pista = _pistaService.GetById(id);

                    if (pista == null)
                    {
                        return NotFound();
                    }

                    pista.Cocheras.Clear();

                    pista.PistaNombre = pistaView.PistaNombre;
                    pista.PistaCodigo = pistaView.PistaCodigo;
                    pista.PistaMaterial = pistaView.PistaMaterial;
                    pista.PistaIluminacion = pistaView.PistaIluminacion;
                    pista.PistaAprovisionamiento = pistaView.PistaAprovisionamiento;

                    var cocheras = _cocheraService.GetAll().Where(c => pistaView.CocheraIds.Contains(c.CocheraId)).ToList();

                    pista.Cocheras.AddRange(cocheras);

                    _pistaService.Update(pista);

                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PistaExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(pistaView);
        }
        
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
