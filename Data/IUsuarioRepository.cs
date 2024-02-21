namespace Teatro.Data;

using Teatro.Models;

public interface IUsuarioRepository
{
    public List<UsuarioGetDTO> GetAllUsuarios();
    public List<Reserva> GetAllReservas();
    public List<Reserva> GetReservasUsuario(int usuarioId);

    public Usuario GetIdUsuario(int idUsuario);
    public Reserva GetIdReserva(int idReserva);

    void CreateUsuario(UsuarioAddDTO usuarioDto);
    void CreateReserva(int usuarioId, Reserva reserva);

    void UpdateUsuario(Usuario usuario);
    void UpdateReserva(Reserva reserva);

    void DeleteUsuario(int idUsuario);
    void DeleteReserva(int idReserva);

    void SaveChanges();
}