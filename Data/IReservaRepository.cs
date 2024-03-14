namespace Teatro.Data;

using Teatro.Models;

public interface IReservaRepository
{
    public List<ReservaGetDTO> GetAllReservas();
    public List<ReservaGetDTO> GetReservasUsuario(int usuarioId);

    public Reserva GetIdReserva(int idReserva);

    void CreateReservas(List<ReservaAddDTO> reservas);

    void UpdateReserva(ReservaPutDTO reserva);

    void DeleteReserva(int idReserva);

    void SaveChanges();
}