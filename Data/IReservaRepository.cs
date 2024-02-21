namespace Teatro.Data;

using Teatro.Models;

public interface IReservaRepository
{
    public List<Reserva> GetAllReservas();
    public List<ReservaGetDTO> GetReservasUsuario(int usuarioId);

    public Reserva GetIdReserva(int idReserva);

    void CreateReserva(int usuarioId, Reserva reserva);

    void UpdateReserva(Reserva reserva);

    void DeleteReserva(int idReserva);

    void SaveChanges();
}