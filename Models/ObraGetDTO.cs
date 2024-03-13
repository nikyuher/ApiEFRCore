namespace Teatro.Models;
public class ObraGetDTO
{
    public int ObraId { get; set; }
    public byte[]? Imagen { get; set; }
    public string? Genero { get; set; }
    public string? Título { get; set; }
    public string? Descripción { get; set; }
    public string? DiaSemana { get; set; }
    public int Hora { get; set; }
    public string? Minuto { get; set; }
    public decimal PrecioEntrada { get; set; }
    public List<Asiento> AsientosOcupados { get; set; } = new List<Asiento>();
}
