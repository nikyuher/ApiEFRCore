namespace Teatro.Business;

using System.Security.Cryptography.X509Certificates;
using Teatro.Data;
using Teatro.Models;
public class UsuarioServices : IUsuarioServices
{

    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioServices(IUsuarioRepository repository)
    {
        _usuarioRepository = repository;
    }


    public List<Usuario> GetAllUsuarios()
    {
        return _usuarioRepository.GetAllUsuarios();
    }

    public Usuario GetIdUsuario(int idUsuario)
    {
        return _usuarioRepository.GetIdUsuario(idUsuario);
    }

    public void CreateUsuario(Usuario usuario)
    {
        _usuarioRepository.CreateUsuario(usuario);
    }

    public void UpdateUsuario(Usuario usuario)
    {
        _usuarioRepository.UpdateUsuario(usuario);
    }

    public void DeleteUsuario(int idUsuario)
    {
        _usuarioRepository.DeleteUsuario(idUsuario);
    }
}
