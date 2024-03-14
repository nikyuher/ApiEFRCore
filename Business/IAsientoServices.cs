namespace Teatro.Business;

using Teatro.Models;

public interface IAsientoServices
{
    List<Asiento> GetAllAsiento();
    public List<Asiento> GetAsientoEstado(bool estado);
    public Asiento GetIdAsiento(int IdAsiento);
    void CreateAsiento(Asiento asiento);
    void AgregarAsientoAObra(List<AsientoOcupadoDTO> ocupadoDTO);
    void UpdateAsiento(Asiento asiento);
    void UpdateEstado(AsientoPutEstadoDTO asiento);
    void DeleteAsiento(int idAsiento);


}
