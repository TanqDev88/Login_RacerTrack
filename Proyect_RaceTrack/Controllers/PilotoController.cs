using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;
using Proyect_RaceTrack.ViewModels.PilotoViewModels;
using Proyect_RaceTrack.Services;
using Proyect_RaceTrack.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Proyect_RaceTrack.Controllers
{
    public class PilotoController : Controller
    {
        private readonly IPilotoService _pilotoService;
        private readonly IVehiculoService _vehiculoService;
        public PilotoController(IPilotoService pilotoService, IVehiculoService vehiculoService)
        {
            _pilotoService = pilotoService;
            _vehiculoService = vehiculoService;
        }
        // GET: Piloto
        //Acceso autorizado para todos los perfiles
        [Authorize(Roles = "Administrador, Propietario, Jefe de pista")]
        public IActionResult Index(string nameFilterIns)
        {
            var model = new PilotoIndexViewModel();
            model.pilotos = _pilotoService.GetAll(nameFilterIns);

            return View(model);
        }

        // GET: Piloto/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = _pilotoService.GetById(id.Value);
            if (piloto == null)
            {
                return NotFound();
            }
            var viewModel = new PilotoDetailViewModel();
            viewModel.PilotoNombre = piloto.PilotoNombre;
            viewModel.PilotoApellido = piloto.PilotoApellido;
            viewModel.PilotoDni = piloto.PilotoDni;
            viewModel.PilotoNumeroLicencia = piloto.PilotoNumeroLicencia;
            viewModel.PilotoExpedicion = piloto.PilotoExpedicion;
            viewModel.PilotoPropietario = piloto.PilotoPropietario;
            viewModel.VehiculoId = piloto.VehiculoId;
            viewModel.Vehiculo = piloto.Vehiculo;

            return View(viewModel);
        }

        // GET: Piloto/Create
        [Authorize(Roles = "Administrador, Jefe de pista")]
        public IActionResult Create()
        {
            ViewData["VehiculoId"] = new SelectList(_vehiculoService.GetAll(), "VehiculoId", "VehiculoTipo");
            return View();
        }

        // POST: Piloto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PilotoId, PilotoNombre, PilotoApellido, PilotoDni, PilotoNumeroLicencia, PilotoExpedicion, PilotoPropietario, VehiculoId")] PilotoCreateViewModel pilotoView)
        {
            if (ModelState.IsValid)
            {
                var piloto = new Piloto
                {
                    PilotoNombre = pilotoView.PilotoNombre,
                    PilotoApellido = pilotoView.PilotoApellido,
                    PilotoDni = pilotoView.PilotoDni,
                    PilotoNumeroLicencia = pilotoView.PilotoNumeroLicencia,
                    PilotoExpedicion = pilotoView.PilotoExpedicion,
                    PilotoPropietario = pilotoView.PilotoPropietario,
                    VehiculoId = pilotoView.VehiculoId
                };

                _pilotoService.Create(piloto);
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehiculoId"] = new SelectList(_vehiculoService.GetAll(), "VehiculoId", "VehiculoTipo");
            return View(pilotoView);
        }

        // GET: Piloto/Edit/5
        [Authorize(Roles = "Administrador, Jefe de pista")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = _pilotoService.GetById(id.Value);
            if (piloto == null)
            {
                return NotFound();
            }

            var viewModel = new PilotoEditViewModel
            {
                PilotoId = piloto.PilotoId,
                PilotoNombre = piloto.PilotoNombre,
                PilotoApellido = piloto.PilotoApellido,
                PilotoDni = piloto.PilotoDni,
                PilotoNumeroLicencia = piloto.PilotoNumeroLicencia,
                PilotoExpedicion = piloto.PilotoExpedicion,
                PilotoPropietario = piloto.PilotoPropietario,
                VehiculoId = piloto.VehiculoId,
                Vehiculo = piloto.Vehiculo
            };

            // Obtén la lista de vehículos y la establece en el ViewBag
            ViewData["VehiculoId"] = new SelectList(_vehiculoService.GetAll(), "VehiculoId", "VehiculoTipo", viewModel.VehiculoId);

            return View(viewModel);
        }

        // POST: Piloto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PilotoId, PilotoNombre, PilotoApellido, PilotoDni, PilotoNumeroLicencia, PilotoExpedicion, PilotoPropietario, VehiculoId")] PilotoEditViewModel pilotoView)
        {
            if (id != pilotoView.PilotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var piloto = new Piloto
                {
                    PilotoId = pilotoView.PilotoId,
                    PilotoNombre = pilotoView.PilotoNombre,
                    PilotoApellido = pilotoView.PilotoApellido,
                    PilotoDni = pilotoView.PilotoDni,
                    PilotoNumeroLicencia = pilotoView.PilotoNumeroLicencia,
                    PilotoExpedicion = pilotoView.PilotoExpedicion,
                    PilotoPropietario = pilotoView.PilotoPropietario,
                    VehiculoId = pilotoView.VehiculoId,
                    Vehiculo = _vehiculoService.GetById(pilotoView.VehiculoId)
                };

                try
                {
                    _pilotoService.Update(piloto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PilotoExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            ViewData["VehiculoId"] = new SelectList(_vehiculoService.GetAll(), "VehiculoId", "VehiculoTipo", pilotoView.VehiculoId);
            return View(pilotoView);
        }

        // GET: Instructor/Delete/5
        [Authorize(Roles = "Administrador, Jefe de pista")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = _pilotoService.GetById(id.Value);
            if (piloto == null)
            {
                return NotFound();
            }
            var viewModel = new PilotoDeleteViewModel();
            viewModel.PilotoNombre = piloto.PilotoNombre;
            viewModel.PilotoApellido = piloto.PilotoApellido;
            viewModel.PilotoDni = piloto.PilotoDni;
            viewModel.PilotoNumeroLicencia = piloto.PilotoNumeroLicencia;
            viewModel.PilotoExpedicion = piloto.PilotoExpedicion;
            viewModel.PilotoPropietario = piloto.PilotoPropietario;
            viewModel.VehiculoId = piloto.VehiculoId;
            viewModel.Vehiculo = piloto.Vehiculo;

            return View(viewModel);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var aeronave = _pilotoService.GetById(id);
            if (aeronave != null)
            {
                _pilotoService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PilotoExists(int id)
        {
            return _pilotoService.GetById(id) != null;
        }
    }
}