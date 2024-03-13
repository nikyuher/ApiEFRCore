namespace Teatro.Models;
public class ObraAddDTO
{
    public int ObraId { get; set; }
    public byte[]? Imagen { get; set; }
    public string? Genero { get; set; }
    public string? Título { get; set; }
    public string? Descripción { get; set; }
    public string? DiaSemana { get; set; }
    public int Hora { get; set; }
    public int Minuto { get; set; }

    public decimal PrecioEntrada { get; set; }
}
