namespace Teatro.Models;
public class Usuario
{
    public int UsuarioId { get; set; }
    
    public string? Nombre { get; set; }
    public string? CorreoElectronico { get; set; }
    public string? Contraseña { get; set; }

    public List<Reserva>? ListReservas { get; set; }
}

