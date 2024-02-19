using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;
using Proyect_RaceTrack.ViewModels.CocheraViewModels;
using Proyect_RaceTrack.Services;
using Proyect_RaceTrack.ViewModels;
using Proyect_RaceTrack.ViewModels.PistaViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Proyect_RaceTrack.Controllers
{
    public class CocheraController : Controller
    {
        private ICocheraService _cocheraService;
        private IPistaService _pistaService;

        public CocheraController(ICocheraService cocheraService, IPistaService pistaService)
        {
            _cocheraService = cocheraService;
            _pistaService = pistaService;
        }

        // GET: Cochera
        [Authorize(Roles = "Administrador, Jefe de pista")]

        public IActionResult Index(string NameFilterCoc)
        {
            var model = new CocheraIndexViewModel();
            model.cocheras = _cocheraService.GetAll(NameFilterCoc);

            return View(model);

        }

        // GET: Cochera/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cochera = _cocheraService.GetById(id.Value);
            if (cochera == null)
            {
                return NotFound();
            }

            return View(cochera);
        }

        // GET: Cochera/Create
        public IActionResult Create()
        {
            ViewData["Pistas"] = new SelectList(_pistaService.GetAll(), "PistaId", "PistaNombre", "nameFilterPista");
            return View();
        }

        // POST: Cochera/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CocheraId, CocheraNombre, CocheraNumero, CocheraSector,CocheraAptoMantenimiento,CocheraOficinas,PistaIds")] CocheraCreateViewModel cocheraView)
        {
            if (ModelState.IsValid)
            {
                var pistas = _pistaService.GetAll().Where(x => cocheraView.PistaIds.Contains(x.PistaId)).ToList();

                var cochera = new Cochera
                {
                    CocheraNombre = cocheraView.CocheraNombre,
                    CocheraNumero = cocheraView.CocheraNumero,
                    CocheraSector = cocheraView.CocheraSector,
                    CocheraAptoMantenimiento = cocheraView.CocheraAptoMantenimiento,
                    CocheraOficinas = cocheraView.CocheraOficinas,
                    Pistas = pistas

                };


                _cocheraService.Create(cochera);
                return RedirectToAction(nameof(Index));
            }
            return View(cocheraView);
        }

        // GET: Cochera/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cochera = _cocheraService.GetById(id.Value);
            ViewData["Pistas"] = new SelectList(_pistaService.GetAll(), "PistaId", "PistaNombre");

            if (cochera == null)
            {
                return NotFound();
            }

            var viewModel = new CocheraEditViewModel();
            viewModel.CocheraId = cochera.CocheraId;
            viewModel.CocheraNombre = cochera.CocheraNombre;
            viewModel.CocheraNumero = cochera.CocheraNumero;
            viewModel.CocheraSector = cochera.CocheraSector;
            viewModel.CocheraAptoMantenimiento = cochera.CocheraAptoMantenimiento;
            viewModel.CocheraOficinas = cochera.CocheraOficinas;
            viewModel.PistaIds = cochera.Pistas.Select(p => p.PistaId).ToList();
            return View(viewModel);
        }

        // POST: Cochera/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CocheraId,CocheraNombre,CocheraNumero,CocheraSector,CocheraAptoMantenimiento,CocheraOficinas,PistaIds")] CocheraEditViewModel cocheraView)
        {
            if (id != cocheraView.CocheraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var cochera = _cocheraService.GetById(id);

                    if (cochera == null)
                    {
                        return NotFound();
                    }

                    cochera.Pistas.Clear();

                    cochera.CocheraNombre = cocheraView.CocheraNombre;
                    cochera.CocheraNumero = cocheraView.CocheraNumero;
                    cochera.CocheraSector = cocheraView.CocheraSector;
                    cochera.CocheraAptoMantenimiento = cocheraView.CocheraAptoMantenimiento;
                    cochera.CocheraOficinas = cocheraView.CocheraOficinas;

                    var pistas = _pistaService.GetAll().Where(p => cocheraView.PistaIds.Contains(p.PistaId)).ToList();

                    cochera.Pistas.AddRange(pistas);

                    _cocheraService.Update(cochera);

                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocheraExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(cocheraView);
        }

        // GET: Cochera/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cochera = _cocheraService.GetById(id.Value);
            if (cochera == null)
            {
                return NotFound();
            }
            var viewModel = new CocheraDeleteViewModel();
            viewModel.CocheraNombre = cochera.CocheraNombre;
            viewModel.CocheraNumero = cochera.CocheraNumero;
            viewModel.CocheraSector = cochera.CocheraSector;
            viewModel.CocheraAptoMantenimiento = cochera.CocheraAptoMantenimiento;
            viewModel.CocheraOficinas = cochera.CocheraOficinas;

            return View(viewModel);

        }

        // POST: Cochera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var cochera = _cocheraService.GetById(id);
            if (cochera != null)
            {
                _cocheraService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CocheraExists(int id)
        {
            return _cocheraService.GetById(id) != null;
        }
    }
}
