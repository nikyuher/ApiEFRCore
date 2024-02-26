namespace Teatro.Data;

using Teatro.Models;

public interface IUsuarioRepository
{
    public List<UsuarioGetDTO> GetAllUsuarios();

    public UsuarioGetDTO GetIdUsuarioDTO(int idUsuario);
    public UsuarioGetRegisterDTO GetRegisterUsuario(string email);

    void CreateUsuario(UsuarioAddDTO usuarioDto);

    void UpdateUsuario(UsuarioPutDTO usuario);

    void DeleteUsuario(int idUsuario);

    void SaveChanges();
}