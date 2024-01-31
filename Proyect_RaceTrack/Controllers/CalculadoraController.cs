using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;

namespace Proyect_RaceTrack.Controllers
{
    public class CalculadoraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalculadoraController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            return _context.Calculadora != null ? 
                        View(await _context.Calculadora.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Calculadora'  is null.");
        }
    }
}
