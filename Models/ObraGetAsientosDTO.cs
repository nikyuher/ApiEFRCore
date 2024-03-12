namespace Teatro.Models;
public class ObraGetAsientosDTO
{
    public int ObraId { get; set; }
    public List<Asiento> AsientosOcupados { get; set; } = new List<Asiento>();

}
