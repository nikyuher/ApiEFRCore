namespace Teatro.Models;

public class ReservaAddDTO
{
    public int ReservaId { get; set; }
    
    public Usuario? Usuario { get; set; }
    public int UsuarioId { get; set; }
}
