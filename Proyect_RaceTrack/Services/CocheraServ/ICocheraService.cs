using System.Security.Cryptography.X509Certificates;
using Proyect_RaceTrack.Data;
using Proyect_RaceTrack.Models;
namespace Proyect_RaceTrack.Services;

public interface ICocheraService
{
    void Create(Cochera obj);
    List<Cochera> GetAll();
    List<Cochera> GetAll(string NameFilterCoc);
    void Update(Cochera obj);
    void Delete(int id);
    Cochera? GetById(int id);

}