namespace Teatro.Models;

public class ReservaGetDTO
{
    public int ReservaId { get; set; }

    public int UsuarioId { get; set; }

    public List<DetalleReserva> Detalles { get; set; } = new List<DetalleReserva>();
}
