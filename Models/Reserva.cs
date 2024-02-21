namespace Teatro.Models;

using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
public class Reserva
{
    [Key]
    public int ReservaId { get; set; }
    
    [JsonIgnore]
    public Usuario? Usuario { get; set; }
    public int UsuarioId { get; set; }

    public List<DetalleReserva> Detalles { get; set; } = new List<DetalleReserva>();
}
