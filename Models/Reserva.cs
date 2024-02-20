namespace Teatro.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class Reserva
{
    [Key]
    public int ReservaId { get; set; }
    
    public Usuario? Usuario { get; set; }
    public int UsuarioId { get; set; }

    public List<ReservaSala>? ListSalas { get; set; }
}
