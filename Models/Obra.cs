namespace Teatro.Models;
using System.ComponentModel.DataAnnotations;
public class Obra
{
    [Key]
    public int ObraId { get; set; }


    public string? Genero { get; set; }
    public string? Título { get; set; }
    public string? Descripción { get; set; }
    public decimal PrecioEntrada { get; set; }

}
