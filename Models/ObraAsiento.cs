namespace Teatro.Models;
using System.ComponentModel.DataAnnotations;

public class ObraAsiento
{
    [Key]
    public int ObraAsientoId { get; set; }
    public int ObraId { get; set; }
    public int AsientoId { get; set; }
    public Asiento? Asiento { get; set; }
}