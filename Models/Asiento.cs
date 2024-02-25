namespace Teatro.Models;
using System.ComponentModel.DataAnnotations;
public class Asiento
{
    [Key]
    public int AsientoId { get; set; }
    
    public string? NumeroAsiento { get; set; }
    public bool? Estado { get; set; }

}
