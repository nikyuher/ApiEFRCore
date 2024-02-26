namespace Teatro.Business;

using System.Net.Http.Headers;
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


    public List<UsuarioGetDTO> GetAllUsuarios()
    {
        return _usuarioRepository.GetAllUsuarios();
    }

    public UsuarioGetDTO GetIdUsuario(int idUsuario)
    {
        return _usuarioRepository.GetIdUsuarioDTO(idUsuario);
    }

    public UsuarioGetRegisterDTO GetRegisterUsuario(string email){
        return _usuarioRepository.GetRegisterUsuario(email);
    }

    public void CreateUsuario(UsuarioAddDTO usuario)
    {
        _usuarioRepository.CreateUsuario(usuario);
    }

    public void UpdateUsuario(UsuarioPutDTO usuario)
    {
        _usuarioRepository.UpdateUsuario(usuario);
    }

    public void DeleteUsuario(int idUsuario)
    {
        _usuarioRepository.DeleteUsuario(idUsuario);
    }

}
