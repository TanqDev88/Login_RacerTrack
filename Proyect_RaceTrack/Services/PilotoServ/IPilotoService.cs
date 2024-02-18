using Proyect_RaceTrack.Models;
namespace Proyect_RaceTrack.Services;
public interface IPilotoService
{
    void Create(Piloto obj);
    List<Piloto> GetAll(string NameFilterCoc);
    void Update(Piloto obj);
    void Delete(int id);
    Piloto? GetById(int id);
}