namespace Teatro.Business;

using Teatro.Data;
using Teatro.Models;
public class AsientoServices : IAsientoServices
{

    private readonly IAsientoRepository _asientoRepository;

    public AsientoServices(IAsientoRepository repository)
    {
        _asientoRepository = repository;
    }

    public List<Asiento> GetAllAsiento()
    {
        return _asientoRepository.GetAllAsiento();
    }

    public List<Asiento> GetAsientoEstado(bool estado){
        return _asientoRepository.GetAsientoEstado(estado);
    }

    public Asiento GetIdAsiento(int idAsiento)
    {
        return _asientoRepository.GetIdAsiento(idAsiento);
    }

    public void CreateAsiento(Asiento asiento)
    {
        _asientoRepository.CreateAsiento(asiento);
    }

    public void AgregarAsientoAObra(AsientoOcupadoDTO ocupadoDTO)
    {
        _asientoRepository.AgregarAsientoAObra(ocupadoDTO);
    }

    public void UpdateAsiento(Asiento asiento)
    {
        _asientoRepository.UpdateAsiento(asiento);
    }

    public void UpdateEstado(AsientoPutEstadoDTO asiento)
    {
        _asientoRepository.UpdateEstado(asiento);
    }

    public void DeleteAsiento(int asiento)
    {
        _asientoRepository.DeleteAsiento(asiento);
    }

}
