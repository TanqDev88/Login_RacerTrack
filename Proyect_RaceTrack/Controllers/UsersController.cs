using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Proyect_RaceTrack.Models;
using Proyect_RaceTrack.ViewModels;

namespace Proyect_RaceTrack.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;

    private readonly RoleManager<IdentityRole> _roleManager;

    public UsersController(
        ILogger<HomeController> logger,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [Authorize(Roles = "Administrador")]
    public IActionResult Index()
    {
        var users = _userManager.Users.ToList();
        return View(users);
    }

    // GET: Usuario/Edit/5
    public async Task<IActionResult> Edit(string Id)
    {
        var user = await _userManager.FindByIdAsync(Id);

        var userViewModel = new UserEditViewModel();
        userViewModel.UserName = user.UserName;


        var rolesList = _roleManager.Roles.ToList();
        userViewModel.Roles = new SelectList(rolesList, nameof(IdentityRole.Name), nameof(IdentityRole.Name), rolesList.FirstOrDefault()?.Name);

        return View(userViewModel);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(UserEditViewModel model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);
        if (user != null)
        {
            var existingRoles = await _userManager.GetRolesAsync(user);
            if (existingRoles.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, existingRoles);
            }

            await _userManager.AddToRoleAsync(user, model.Role);
        }

        return RedirectToAction("Index");
    }

}