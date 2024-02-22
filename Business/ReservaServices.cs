namespace Teatro.Business;

using Teatro.Data;
using Teatro.Models;
public class ReservaServices : IReservaServices
{

    private readonly IReservaRepository _reservaRepository;

    public ReservaServices(IReservaRepository repository)
    {
        _reservaRepository = repository;
    }


    public List<ReservaGetDTO> GetAllReservas()
    {
        return _reservaRepository.GetAllReservas();
    }

    public List<ReservaGetDTO> GetReservasUsuario(int usuarioId)
    {
        return _reservaRepository.GetReservasUsuario(usuarioId);
    }

    public Reserva GetIdReserva(int idReserva)
    {
        return _reservaRepository.GetIdReserva(idReserva);
    }

    public void CreateReserva(ReservaAddDTO reserva)
    {
        _reservaRepository.CreateReserva(reserva);
    }

    public void UpdateReserva(ReservaPutDTO reserva)
    {
        _reservaRepository.UpdateReserva(reserva);
    }

    public void DeleteReserva(int idReserva)
    {
        _reservaRepository.DeleteReserva(idReserva);
    }
}
