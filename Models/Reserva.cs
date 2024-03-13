namespace Teatro.Models;

using System.ComponentModel.DataAnnotations;
public class Reserva
{
    [Key]
    public int ReservaId { get; set; }
    
    [Required]
    public int UsuarioId { get; set; }

    [Required]
    public int ObraId { get; set; }
    public Obra? Obra { get; set; }

    [Required]
    public int AsientoId{get;set;}
    public Asiento? Asiento {get;set;}

}
