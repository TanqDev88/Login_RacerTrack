using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Models;

namespace Proyect_RaceTrack.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Proyect_RaceTrack.Models.Vehiculo> Vehiculo { get; set; } = default!;
    public DbSet<Proyect_RaceTrack.Models.Piloto> Piloto { get; set; } = default!;
    public DbSet<Proyect_RaceTrack.Models.Pista> Pista { get; set; } = default!;
    public DbSet<Proyect_RaceTrack.Models.Cochera> Cochera { get; set; } = default!;
    public DbSet<Proyect_RaceTrack.Models.Calculadora> Calculadora { get; set; } = default!;
}
