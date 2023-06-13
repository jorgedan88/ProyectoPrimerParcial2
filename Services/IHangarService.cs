using ProyectoPrimerParcial.Models;


namespace ProyectoPrimerParcial2.Services;

public interface IHangarService
{
    void Create(Hangar obj);
    List<Hangar> GetAll();
    void Update(Hangar obj);

    void Delete(Hangar obj);
    Hangar GetById(int id);

}