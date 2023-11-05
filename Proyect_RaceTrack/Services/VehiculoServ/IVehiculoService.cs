using Proyect_RaceTrack.Models;
namespace Proyect_RaceTrack.Services;
public interface IVehiculoService
{
    void Create(Vehiculo obj);
    List<Vehiculo> GetAll();
    List<Vehiculo> GetAll(string NameFilterVeh);
    void Update(Vehiculo obj);
    void Delete(int id);
    Vehiculo? GetById(int id);

}