using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Models;

using Proyect_RaceTrack.Services;
using Proyect_RaceTrack.ViewModels;
using Proyect_RaceTrack.ViewModels.VehiculoViewModels;

namespace Proyect_RaceTrack.Controllers
{
    public class VehiculoController : Controller
    {
        private IVehiculoService _vehiculoService;
        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;

        }

        // GET: Vehiculo
        [Authorize(Roles = "Administrador, Propietario, Jefe de pista")]
        public IActionResult Index(string NameFilterVeh)
        {
            var model = new VehiculoIndexViewModel();
            model.vehiculos = _vehiculoService.GetAll(NameFilterVeh);

            return View(model);

        }

        // GET: Vehiculo/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = _vehiculoService.GetById(id.Value);
            if (vehiculo == null)
            {
                return NotFound();
            }

            var viewModel = new VehiculoDetailViewModel();
            viewModel.VehiculoNombre = vehiculo.VehiculoNombre;
            viewModel.VehiculoApellido = vehiculo.VehiculoApellido;
            viewModel.VehiculoMatricula = vehiculo.VehiculoMatricula;
            viewModel.VehiculoTipo = vehiculo.VehiculoTipo;
            viewModel.VehiculoFabricacion = vehiculo.VehiculoFabricacion;
            return View(viewModel);
        }

        // GET: Vehiculo/Create
        [Authorize(Roles = "Administrador, Jefe de pista")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehiculo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("VehiculoNombre,VehiculoApellido,VehiculoMatricula,VehiculoFabricacion, VehiculoTipo")] VehiculoCreateViewModel vehiculoView)
        {
            if (ModelState.IsValid)
            {
                var vehiculo = new Vehiculo
                {
                    VehiculoNombre = vehiculoView.VehiculoNombre,
                    VehiculoApellido = vehiculoView.VehiculoApellido,
                    VehiculoMatricula = vehiculoView.VehiculoMatricula,
                    VehiculoFabricacion = vehiculoView.VehiculoFabricacion,
                    VehiculoTipo = vehiculoView.VehiculoTipo,
                };

                _vehiculoService.Create(vehiculo);
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculoView);
        }

        // GET: Vehiculo/Edit/5
        [Authorize(Roles = "Administrador, Jefe de pista")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = _vehiculoService.GetById(id.Value);
            if (vehiculo == null)
            {
                return NotFound();
            }

            var viewModel = new VehiculoEditViewModel();
            viewModel.VehiculoId = vehiculo.VehiculoId;
            viewModel.VehiculoNombre = vehiculo.VehiculoNombre;
            viewModel.VehiculoApellido = vehiculo.VehiculoApellido;
            viewModel.VehiculoMatricula = vehiculo.VehiculoMatricula;
            viewModel.VehiculoFabricacion = vehiculo.VehiculoFabricacion;
            viewModel.VehiculoTipo = vehiculo.VehiculoTipo;

            return View(viewModel);
        }

        // POST: Vehiculo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("VehiculoId,VehiculoNombre,VehiculoApellido,VehiculoMatricula,VehiculoFabricacion, VehiculoTipo")] VehiculoEditViewModel vehiculoView)
        {
            if (id != vehiculoView.VehiculoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var vehiculo = new Vehiculo();
                vehiculo.VehiculoId = vehiculoView.VehiculoId;
                vehiculo.VehiculoNombre = vehiculoView.VehiculoNombre;
                vehiculo.VehiculoApellido = vehiculoView.VehiculoApellido;
                vehiculo.VehiculoMatricula = vehiculoView.VehiculoMatricula;
                vehiculo.VehiculoFabricacion = vehiculoView.VehiculoFabricacion;
                vehiculo.VehiculoTipo = vehiculoView.VehiculoTipo;
            
                try
                {
                _vehiculoService.Update(vehiculo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.VehiculoId))
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
            return View(vehiculoView);
        }


        // GET: Vehiculo/Delete/5
        [Authorize(Roles = "Administrador, Jefe de pista")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = _vehiculoService.GetById(id.Value);
            if (vehiculo == null)
            {
                return NotFound();
            }
            var viewModel = new VehiculoDeleteViewModel();
            viewModel.VehiculoNombre = vehiculo.VehiculoNombre;
            viewModel.VehiculoApellido = vehiculo.VehiculoApellido;
            viewModel.VehiculoMatricula = vehiculo.VehiculoMatricula;
            viewModel.VehiculoTipo = vehiculo.VehiculoTipo;
            viewModel.VehiculoFabricacion = vehiculo.VehiculoFabricacion;

            return View(viewModel);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var vehiculo = _vehiculoService.GetById(id);
            if (vehiculo != null)
            {
                _vehiculoService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
            return _vehiculoService.GetById(id) != null;
        }   
    }
}
