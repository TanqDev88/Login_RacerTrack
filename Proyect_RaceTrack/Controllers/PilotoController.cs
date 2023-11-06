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
        public IActionResult Index(string nameFilterIns)
        {
            // var query = from instructor in _context.Instructor.Include(i => i.Aeronave) select instructor;

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
                // .Include(p => p.Vehiculo)
                // .FirstOrDefaultAsync(m => m.PilotoId == id);
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
            //viewModel.Pi = piloto.PilotoEnActividad;
            viewModel.VehiculoId = piloto.VehiculoId;
            viewModel.Vehiculo = piloto.Vehiculo;

            return View(viewModel);
        }

        // GET: Piloto/Create
        public IActionResult Create()
        {
            // ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "AeronaveTipo",  "instructor.AeronaveId");
            // ViewData["AeronaveId"] = new SelectList(_aeronaveService.GetAll(), "AeronaveId", "AeronaveTipo",  "instructor.AeronaveId", "nameFilter");
            ViewData["VehiculoId"] = new SelectList(_vehiculoService.GetAll(), "VehiculoId", "VehiculoTipo", "nameFilter");
            // ViewData["AeronaveId"] = new SelectList(_aeronaveService.GetAll(), "AeronaveId", "instructor.AeronaveId", "nameFilter");
            // ViewData["AeronaveId"] = new SelectList(_aeronaveService.GetAll(), "AeronaveTipo",  "instructor.AeronaveId", "nameFilter");
            return View();
        }

        // POST: Instructor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PilotoId, PilotoNombre, PilotoApellido, PilotoDni, PilotoNumeroLicencia, PilotoExpedicion, PilotoPropietar, VehiculoId")] PilotoCreateViewModel pilotoView)
        {
            if (ModelState.IsValid)
            {
                var instructor = new Piloto
                {
                    PilotoNombre = pilotoView.PilotoNombre,
                    PilotoApellido = pilotoView.PilotoApellido,
                    PilotoDni = pilotoView.PilotoDni,
                    //PilotoTipoLicencia = pilotoView.InstructorTipoLicencia,
                    PilotoNumeroLicencia = pilotoView.PilotoNumeroLicencia,
                    PilotoExpedicion = pilotoView.PilotoExpedicion,
                    //PilotoEnActividad = pilotoView.PilotoEnActividad,
                    VehiculoId = pilotoView.VehiculoId

                };
                _pilotoService.Create(instructor);
                return RedirectToAction(nameof(Index));
            }
            // ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "TipoAeronave",  "instructor.AeronaveId");
            return View(pilotoView);
        }

        // GET: Instructor/Edit/5      
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = _pilotoService.GetById(id.Value);
            //ViewData["VehiculoId"] = new SelectList(_contextVehiculo, "VehiculoId", "TipoVehiculo", "piloto.VehiculoId");
            ViewData["VehiculoId"] = new SelectList(_vehiculoService.GetAll(), "VehiculoId", "VehiculoTipo", "nameFilter");
            if (piloto == null)
            {
                return NotFound();
            }
            return View(piloto);
        }
        // POST: Instructor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PilotoId, PilotoNombre, PilotoApellido, PilotoDni, PilotoNumeroLicencia, PilotoExpedicion, PilotoPropietar, VehiculoId")] Piloto piloto)
        {
            if (id != piloto.PilotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _pilotoService.Update(piloto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PilotoExists(piloto.PilotoId))
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

            return View(piloto);
        }

        // GET: Instructor/Delete/5
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
            //viewModel.Pi = instructor.InstructorEnActividad;
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
