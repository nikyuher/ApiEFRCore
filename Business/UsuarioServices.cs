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

    public List<Reserva> GetAllReservas()
    {
        return _usuarioRepository.GetAllReservas();
    }

    public List<Reserva> GetReservasUsuario(int usuarioId)
    {
        return _usuarioRepository.GetReservasUsuario(usuarioId);
    }

    public UsuarioGetDTO GetIdUsuario(int idUsuario)
    {
        return _usuarioRepository.GetIdUsuarioDTO(idUsuario);
    }

    public Reserva GetIdReserva(int idReserva)
    {
        return _usuarioRepository.GetIdReserva(idReserva);
    }

    public void CreateUsuario(UsuarioAddDTO usuario)
    {
        _usuarioRepository.CreateUsuario(usuario);
    }

    public void CreateReserva(int usuarioId, Reserva reserva)
    {
        _usuarioRepository.CreateReserva(usuarioId, reserva);
    }

    public void UpdateUsuario(UsuarioPutDTO usuario)
    {
        _usuarioRepository.UpdateUsuario(usuario);
    }

    public void UpdateReserva(Reserva reserva)
    {
        _usuarioRepository.UpdateReserva(reserva);
    }

    public void DeleteUsuario(int idUsuario)
    {
        _usuarioRepository.DeleteUsuario(idUsuario);
    }

    public void DeleteReserva(int idReserva)
    {
        _usuarioRepository.DeleteReserva(idReserva);
    }
}
