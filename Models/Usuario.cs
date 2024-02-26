namespace Teatro.Models;
using System.ComponentModel.DataAnnotations;
public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }

    public bool Rol { get; set; }
    
    [Required]
    public string? Nombre { get; set; }

    [Required]
    public string? CorreoElectronico { get; set; }

    [Required]
    public string? Contraseña { get; set; }

    public List<Reserva> ListReservas { get; set; } = new List<Reserva>();
}

