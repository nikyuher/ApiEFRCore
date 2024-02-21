namespace Teatro.Business;

using Teatro.Models;
public interface IUsuarioServices
{
    public List<Usuario> GetAllUsuarios();
    public List<Reserva> GetAllReservas();
    public List<Reserva> GetReservasUsuario(int usuarioId);

    public Usuario GetIdUsuario(int idUsuario);
    public Reserva GetIdReserva(int idReserva);

    void CreateUsuario(Usuario usuario);
    void CreateReserva(int usuarioId, Reserva reserva);

    void UpdateUsuario(Usuario usuario);
    void UpdateReserva(Reserva reserva);

    void DeleteUsuario(int idUsuario);
    void DeleteReserva(int idReserva);
}
