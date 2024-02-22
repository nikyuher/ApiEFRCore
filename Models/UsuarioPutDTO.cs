namespace Teatro.Models;

public class UsuarioPutDTO
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }
    public string? CorreoElectronico { get; set; }
    public string? Contraseña { get; set; }
}

