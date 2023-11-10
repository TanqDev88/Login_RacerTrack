using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;

namespace Proyect_RaceTrack.Services;

public class PistaService : IPistaService
{
    private readonly ApplicationDbContext _context;
    public PistaService(ApplicationDbContext context)
    {

        _context = context;

    }
    public void Create(Pista obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var obj = GetById(id);
            if (obj != null)
            {
                _context.Pista.Remove(obj);
                _context.SaveChanges();
            }
    }

    public List<Pista> GetAll()
    {
        var query = from pista in _context.Pista select pista;
        return query.ToList();
    }
//OJO QUE ESTO ESTA AGREGADO DE PRUEBA
    public List<Pista> GetAll(string nameFilterPista){
    var query = from pista in _context.Pista select pista;

        if (!string.IsNullOrEmpty(nameFilterPista))
        {
                query = query.Where(x => x.PistaNombre.Contains(nameFilterPista) || x.PistaCodigo.ToString() == nameFilterPista);
        }
        return query.ToList();
    }

    public Pista? GetById(int id)
    {
            var pista = _context.Pista
                .Include(r => r.Cocheras)
                .FirstOrDefault(m => m.PistaId == id);
            return pista;  
    }

    public void Update(Pista obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
}
