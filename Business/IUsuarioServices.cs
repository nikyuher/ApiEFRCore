namespace Teatro.Business;

using Teatro.Models;
public interface IUsuarioServices
{
    public List<UsuarioGetDTO> GetAllUsuarios();

    public UsuarioGetDTO GetIdUsuario(int idUsuario);

    public Usuario Login(UsuarioLoginDTO loginDTO);
    void CreateUsuario(UsuarioAddDTO usuario);

    void UpdateUsuario(UsuarioPutDTO usuario);

    void DeleteUsuario(int idUsuario);
}
