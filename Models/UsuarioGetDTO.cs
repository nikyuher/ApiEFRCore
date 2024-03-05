namespace Teatro.Models;

public class UsuarioGetDTO
{
    public int UsuarioId { get; set; }

    public bool Rol { get; set; }
    public string? Nombre { get; set; }
    public string? CorreoElectronico { get; set; }
    public string? Contraseña { get; set; }

}

