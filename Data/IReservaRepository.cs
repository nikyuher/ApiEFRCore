namespace Teatro.Data;

using Teatro.Models;

public interface IReservaRepository
{
    public List<ReservaGetDTO> GetAllReservas();
    public List<ReservaGetDTO> GetReservasUsuario(int usuarioId);

    public Reserva GetIdReserva(int idReserva);

    void CreateReserva(int usuarioId, ReservaAddDTO reserva);

    void UpdateReserva(Reserva reserva);

    void DeleteReserva(int idReserva);
    void AgregarDetalleReserva(int idReserva, int idObra, List<Asiento> asientos);

    void SaveChanges();
}