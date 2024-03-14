namespace Teatro.Business;

using Teatro.Models;

public interface IReservaServices
{
    public List<ReservaGetDTO> GetAllReservas();
    public List<ReservaGetDTO> GetReservasUsuario(int usuarioId);

    public Reserva GetIdReserva(int idReserva);

    void CreateReservas(List<ReservaAddDTO> reservas);

    void UpdateReserva(ReservaPutDTO reserva);

    void DeleteReserva(int idReserva);
}