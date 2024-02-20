namespace Teatro.Models;

public class Asiento
{
    public int AsientoId { get; set; }
    
    public string? NumeroFila { get; set; }
    public string? NumeroAsiento { get; set; }
    public bool? Estado { get; set; }

}
