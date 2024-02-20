namespace Teatro.Business;

using Teatro.Models;
public interface IUsuarioServices
{
    public List<Usuario> GetAllUsuarios();
    public Usuario GetIdUsuario(int idUsuario);
    void CreateUsuario(Usuario usuario);
    void UpdateUsuario(Usuario usuario);
    void DeleteUsuario(int idUsuario);
}
