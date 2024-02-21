using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proyect_RaceTrack.Models;
using Proyect_RaceTrack.ViewModels;

namespace Proyect_RaceTrack.Controllers;

public class RolesController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RolesController(
        ILogger<HomeController> logger,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _roleManager = roleManager;
    }

    [Authorize(Roles = "Administrador")]
    public IActionResult Index()
    {
        var roles = _roleManager.Roles.ToList();
        return View(roles);
    }
    // GET: Rol/Create
    public IActionResult Create()
    {
        return View();
    }
    // POST: Rol/Create
    [HttpPost]
    public IActionResult Create(RoleCreateViewModel model)
    {
        if (string.IsNullOrEmpty(model.RoleName))
        {
            return View();
        }

        var role = new IdentityRole(model.RoleName);
        _roleManager.CreateAsync(role);

        return RedirectToAction("Index");
    }
    // GET: Rol/Edit
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);

        if (role == null)
        {
            return NotFound();
        }

        var model = new RoleEditViewModel
        {
            RoleId = role.Id,
            RoleName = role.Name
        };

        return View(model);
    }

    // POST: Rol/Edit
    [HttpPost]
    public async Task<IActionResult> Edit(RoleEditViewModel model)
    {
        if (string.IsNullOrEmpty(model.RoleName))
        {
            return View(model);
        }

        var role = await _roleManager.FindByIdAsync(model.RoleId);

        if (role == null)
        {
            return NotFound();
        }

        role.Name = model.RoleName;
        await _roleManager.UpdateAsync(role);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);

        if (role == null)
        {
            return NotFound();
        }

        var model = new RoleDeleteViewModel
        {
            RoleId = role.Id,
            RoleName = role.Name
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(RoleDeleteViewModel model)
    {
        if (string.IsNullOrEmpty(model.RoleId))
        {
            return NotFound();
        }

        var role = await _roleManager.FindByIdAsync(model.RoleId);

        if (role == null)
        {
            return NotFound();
        }

        await _roleManager.DeleteAsync(role);

        return RedirectToAction("Index");
    }
}
