namespace Teatro.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class Sala
{
    [Key]
    public int SalaId { get; set; }
    
    public string? NombreSala { get; set; }

    public List<DetalleSala> Detalles { get; set; } = new List<DetalleSala>();
}
