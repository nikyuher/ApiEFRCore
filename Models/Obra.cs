namespace Teatro.Models;
using System.ComponentModel.DataAnnotations;
public class Obra
{
    [Key]
    public int ObraId { get; set; }

    public byte[]? Imagen { get; set; }

    [Required]
    public string? Genero { get; set; }

    [Required]
    public string? Título { get; set; }

    [Required]
    public string? Descripción { get; set; }
    
    [Required]
    public DateTime FechaHora { get; set; }

    [Required]
    public decimal PrecioEntrada { get; set; }

    public List<Asiento> AsientosOcupados { get; set; } = new List<Asiento>();

}
