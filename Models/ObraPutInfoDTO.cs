namespace Teatro.Models;
public class ObraPutInfoDTO
{
    public int ObraId { get; set; }
    public string? Genero { get; set; }
    public string? Título { get; set; }
    public string? Descripción { get; set; }
    public DateTime FechaHora { get; set; }
    public decimal PrecioEntrada { get; set; }

}
