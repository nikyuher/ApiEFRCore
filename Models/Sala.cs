namespace Teatro.Models;

public class Sala
{
    public int SalaId { get; set; }
    
    public string? NombreSala { get; set; }

    public List<DetalleSala>? Detalles { get; set; }
}
