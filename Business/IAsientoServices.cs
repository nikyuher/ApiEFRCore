namespace Teatro.Business;

using Teatro.Models;

public interface IAsientoServices
{
    List<Asiento> GetAllAsiento();
    public Asiento GetIdAsiento(int IdAsiento);
    void CreateAsiento(Asiento asiento);
    void UpdateAsiento(Asiento asiento);
    void UpdateEstado(AsientoPutEstadoDTO asiento);
    void DeleteAsiento(int idAsiento);


}
