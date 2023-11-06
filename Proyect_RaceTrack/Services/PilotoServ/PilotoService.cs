using System.Security.Cryptography.X509Certificates;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace Proyect_RaceTrack.Services;

public class PilotoService : IPilotoService

{
    private readonly ApplicationDbContext _context;
    public PilotoService(ApplicationDbContext context)
    {

        _context = context;

    }
    public void Create(Piloto obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var obj = GetById(id);
            if (obj != null)
            {
                _context.Piloto.Remove(obj);
                _context.SaveChanges();
            }
    }

    public List<Piloto> GetAll()
    {
        var query = from piloto in _context.Piloto.Include(i => i.Vehiculo) select piloto;
        return query.ToList();
    }

    public List<Piloto> GetAll(string nameFilterIns){
        var query = from piloto in _context.Piloto.Include(i => i.Vehiculo) select piloto;

        if (!string.IsNullOrEmpty(nameFilterIns))
        {
            query = query.Where(x => x.PilotoNombre.Contains(nameFilterIns) || x.PilotoApellido.Contains(nameFilterIns) || x.PilotoDni.ToString() == nameFilterIns);
        }
        return query.ToList();

    }

    public Piloto? GetById(int id)
    {
            var piloto = _context.Piloto
            .Include(p => p.Vehiculo)
                .FirstOrDefault(m => m.PilotoId == id);
                
            return piloto;  
    }

    public void Update(Piloto obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
}
