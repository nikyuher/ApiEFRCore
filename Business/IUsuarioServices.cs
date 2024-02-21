namespace Teatro.Business;

using Teatro.Models;
public interface IUsuarioServices
{
    public List<UsuarioGetDTO> GetAllUsuarios();
    public List<Reserva> GetAllReservas();
    public List<Reserva> GetReservasUsuario(int usuarioId);

    public UsuarioGetDTO GetIdUsuario(int idUsuario);
    public Reserva GetIdReserva(int idReserva);

    void CreateUsuario(UsuarioAddDTO usuario);
    void CreateReserva(int usuarioId, Reserva reserva);

    void UpdateUsuario(UsuarioPutDTO usuario);
    void UpdateReserva(Reserva reserva);

    void DeleteUsuario(int idUsuario);
    void DeleteReserva(int idReserva);
}
