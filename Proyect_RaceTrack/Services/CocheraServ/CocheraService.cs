using System.Security.Cryptography.X509Certificates;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;
namespace Proyect_RaceTrack.Services;

public class CocheraService : ICocheraService
{
    private readonly ApplicationDbContext _context;
    public CocheraService(ApplicationDbContext context)
    {

        _context = context;

    }
    public void Create(Cochera obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var obj = GetById(id);
        if (obj != null)
        {
            _context.Cochera.Remove(obj);
            _context.SaveChanges();
        }
    }

    public List<Cochera> GetAll()
    {
        var query = from cochera in _context.Cochera select cochera;
        return query.ToList();
    }

    public List<Cochera> GetAll(string NameFilterCoc)
    {
        var query = from cochera in _context.Cochera select cochera;

        if (!string.IsNullOrEmpty(NameFilterCoc))
        {
            query = query.Where(x => x.CocheraNombre.Contains(NameFilterCoc) || x.CocheraNumero.ToString() == NameFilterCoc);
        }
        return query.ToList();

    }

    // public void GEtById(Hangar obj)
    // {
    //     throw new NotImplementedException();
    // }


    public Cochera? GetById(int id)
    {
        var cochera = _context.Cochera
            .FirstOrDefault(m => m.CocheraId == id);
        return cochera;
    }

    public void Update(Cochera obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
}
