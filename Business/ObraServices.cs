namespace Teatro.Business;

using Teatro.Data;
using Teatro.Models;
public class ObraServices : IObraServices
{

    private readonly IObraRepository _obraRepository;

    public ObraServices(IObraRepository repository)
    {
        _obraRepository = repository;
    }

    public List<Obra> GetAllObras()
    {
        return _obraRepository.GetAllObras();
    }

    public Obra GetIdObra(int idObra)
    {
        return _obraRepository.GetIdObra(idObra);
    }

    public void CreateObra(Obra obra)
    {
        _obraRepository.CreateObra(obra);
    }

    public void UpdateObra(Obra obra)
    {
        _obraRepository.UpdateObra(obra);
    }

    public void DeleteObra(int obra)
    {
        _obraRepository.DeleteObra(obra);
    }

    public void AgregarDetalleReserva(int idReserva, int idObra, List<Asiento> asientos)
    {
        _obraRepository.AgregarDetalleReserva(idReserva, idObra, asientos);
    }

}
