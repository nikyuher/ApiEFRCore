namespace Teatro.Models;

public class Reserva
{
    public int ReservaId { get; set; }
    
    public Usuario? Usuario { get; set; }
    public int UsuarioId { get; set; }

    public List<ReservaSala>? ListSalas { get; set; }
}
