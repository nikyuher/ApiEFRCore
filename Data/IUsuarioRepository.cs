namespace Teatro.Data;

using Teatro.Models;

public interface IUsuarioRepository
{
    public List<UsuarioGetDTO> GetAllUsuarios();

    public UsuarioGetDTO GetIdUsuarioDTO(int idUsuario);
    public UsuarioGetLoginDTO GetLogin(string email, string password);
    public UsuarioGetDTO Login(string email, string password);

    void CreateUsuario(UsuarioAddDTO usuarioDto);

    void UpdateUsuario(UsuarioPutDTO usuario);

    void DeleteUsuario(int idUsuario);

    void SaveChanges();
}