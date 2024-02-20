namespace Teatro.Models;

public class Obra
{
    public int ObraId { get; set; }
    
    public string? Título { get; set; }
    public string? Descripción { get; set; }
    public decimal PrecioEntrada { get; set; }

}
