namespace Teatro.Business;

using Teatro.Models;

public interface IReservaServices
{
    public List<Reserva> GetAllReservas();
    public List<ReservaGetDTO> GetReservasUsuario(int usuarioId);

    public Reserva GetIdReserva(int idReserva);

    void CreateReserva(int usuarioId, Reserva reserva);

    void UpdateReserva(Reserva reserva);

    void DeleteReserva(int idReserva);
}