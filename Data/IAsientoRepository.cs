namespace Teatro.Data;
using Teatro.Models;

public interface IAsientoRepository
{
    public List<Asiento> GetAllAsiento();
    public List<Asiento> GetAsientoEstado(bool estado);
    public Asiento GetIdAsiento(int idAsiento);
    void CreateAsiento(Asiento asiento);
    void AgregarAsientoAObra(AsientoOcupadoDTO ocupadoDTO);
    void UpdateAsiento(Asiento asiento);
    void UpdateEstado(AsientoPutEstadoDTO asiento);
    void DeleteAsiento(int idAsiento);
    void SaveChanges();
}