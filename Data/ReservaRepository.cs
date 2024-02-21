namespace Teatro.Data;

using Microsoft.EntityFrameworkCore;
using Teatro.Models;

public class ReservaRepository : IReservaRepository
{
    private readonly TeatroContext _context;

    public ReservaRepository(TeatroContext context)
    {
        _context = context;
    }

    public List<Reserva> GetAllReservas()
    {
        return _context.Reservas.Include(p => p.Detalles).ToList();
    }

    public Usuario GetIdUser(int idUser)
    {
        var user = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == idUser);

        if (user is null)
        {
            throw new InvalidOperationException($"No se encontro la Reserva con el ID {idUser}");
        }

        return user;
    }

    public Reserva GetIdReserva(int idReserva)
    {
        var reserva = _context.Reservas.FirstOrDefault(u => u.ReservaId == idReserva);

        if (reserva is null)
        {
            throw new InvalidOperationException($"No se encontro la Reserva con el ID {idReserva}");
        }

        return reserva;
    }

    public List<ReservaGetDTO> GetReservasUsuario(int usuarioId)
    {
        var reservasDTO = _context.Reservas
                            .Include(r => r.Detalles)
                            .Where(r => r.UsuarioId == usuarioId)
                            .Select(r => new ReservaGetDTO
                                {
                                    ReservaId = r.ReservaId,
                                    UsuarioId = r.UsuarioId,
                                    Detalles = r.Detalles
                                })
                            .ToList();
        return reservasDTO;
    }

    public void CreateReserva(int usuarioId, Reserva reserva)
    {
        var usuario = _context.Usuarios.Include(u => u.ListReservas).FirstOrDefault(u => u.UsuarioId == usuarioId);

        if (usuario == null)
        {
            throw new InvalidOperationException($"No se encontró ningún usuario con el Id {usuarioId}.");
        }

        usuario.ListReservas.Add(reserva);
        SaveChanges();
    }

    public void UpdateReserva(Reserva reserva)
    {
        var update = GetIdReserva(reserva.ReservaId);

        if (update is null)
        {
            throw new KeyNotFoundException($"No se encontró la reserva con el ID {reserva.ReservaId}.");
        }

        _context.Entry(update).CurrentValues.SetValues(reserva);
        SaveChanges();
    }

    public void DeleteReserva(int idReserva)
    {
        var reserva = GetIdReserva(idReserva);

        if (reserva is null)
        {
            throw new InvalidOperationException($"No se encontró la Reserva con el ID {idReserva}");
        }

        _context.Reservas.Remove(reserva);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}