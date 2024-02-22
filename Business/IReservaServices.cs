namespace Teatro.Business;

using Teatro.Models;

public interface IReservaServices
{
    public List<ReservaGetDTO> GetAllReservas();
    public List<ReservaGetDTO> GetReservasUsuario(int usuarioId);

    public Reserva GetIdReserva(int idReserva);

    void CreateReserva(int usuarioId, ReservaAddDTO reserva);

    void UpdateReserva(Reserva reserva);

    void DeleteReserva(int idReserva);
}