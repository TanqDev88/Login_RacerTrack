using Proyect_RaceTrack.Models;
namespace Proyect_RaceTrack.Services;

public interface IPistaService{
    void Create(Pista obj);
    List<Pista> GetAll();
    List<Pista> GetAll(string nameFilterPista);
    void Update(Pista obj);
    void Delete(int id);
    Pista? GetById(int id);

}