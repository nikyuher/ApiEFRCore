namespace Teatro.Models;

public class ReservaSala
{
    public int SalaId { get; set; }
    public int ReservaId { get; set; }
    
    public Sala? Sala { get; set; }
    public Reserva? Reserva { get; set; }

}
