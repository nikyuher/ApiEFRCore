namespace Teatro.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class DetalleReserva
{
    public int ReservaId { get; set; }
    public int ObraId { get; set; }

    public Reserva? Reserva { get; set; }
    public Obra? Obra { get; set; }

    public List<Asiento> Asientos { get; set; } = new List<Asiento>();
}