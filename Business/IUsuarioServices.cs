namespace Teatro.Business;

using Teatro.Models;
public interface IUsuarioServices
{
    public List<UsuarioGetDTO> GetAllUsuarios();

    public UsuarioGetDTO GetIdUsuario(int idUsuario);

    public UsuarioGetLoginDTO GetLogin(string email, string password);

    public UsuarioGetDTO Login(string email, string password);
    void CreateUsuario(UsuarioAddDTO usuario);

    void UpdateUsuario(UsuarioPutDTO usuario);

    void DeleteUsuario(int idUsuario);
}
