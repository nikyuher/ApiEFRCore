namespace Teatro.Models;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
public class DetalleReserva
{
    public int ReservaId { get; set; }
    public int ObraId { get; set; }
    [JsonIgnore]
    public Reserva? Reserva { get; set; }
    public Obra? Obra { get; set; }

    public List<Asiento> Asientos { get; set; } = new List<Asiento>();
}