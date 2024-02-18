using System.Security.Cryptography.X509Certificates;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;
using Microsoft.EntityFrameworkCore;
namespace Proyect_RaceTrack.Services;

public class VehiculoService : IVehiculoService
{
    private readonly ApplicationDbContext _context;
    public VehiculoService(ApplicationDbContext context)
    {

        _context = context;

    }
    public void Create(Vehiculo obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var obj = GetById(id);
        if (obj != null)
        {
            _context.Vehiculo.Remove(obj);
            _context.SaveChanges();
        }
    }

    public List<Vehiculo> GetAll()
    {
        var query = from vehiculo in _context.Vehiculo select vehiculo;
        return query.ToList();
    }

    public List<Vehiculo> GetAll(string NameFilterVeh)
    {
        IQueryable<Vehiculo> query = _context.Vehiculo;  

        if (!string.IsNullOrEmpty(NameFilterVeh))
        {
            var filterUpper = NameFilterVeh.ToUpper();
            query = query.AsEnumerable().Where(x =>
                (x.VehiculoTipo != null && x.VehiculoTipo.ToString().ToUpper().Contains(filterUpper)) ||
                (x.VehiculoMatricula != null && x.VehiculoMatricula.ToUpper().Contains(filterUpper))
            ).AsQueryable();  
        }

        return query.ToList();
    }

    public Vehiculo? GetById(int id)
    {
        var vehiculo = _context.Vehiculo

            .FirstOrDefault(m => m.VehiculoId == id);
        return vehiculo;
    }

    public void Update(Vehiculo obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
}
