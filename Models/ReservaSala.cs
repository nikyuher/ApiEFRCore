namespace Teatro.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class ReservaSala
{
    public int ReservaSalaId { get; set; }

    public int SalaId { get; set; }
    public int ReservaId { get; set; }

    public Sala? Sala { get; set; }
    public Reserva? Reserva { get; set; }

}
