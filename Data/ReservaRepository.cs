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

    public List<ReservaGetDTO> GetAllReservas()
    {
        var reservas = _context.Reservas.Include(p => p.Detalles).ToList();

        var reservasDTO = reservas.Select(reserva =>
            new ReservaGetDTO
            {
                ReservaId = reserva.ReservaId,
                UsuarioId = reserva.UsuarioId,
                Detalles = reserva.Detalles
            }).ToList();

        return reservasDTO;
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

    public void CreateReserva(int usuarioId, ReservaAddDTO reservaDTO)
    {
        var usuario = _context.Usuarios.Include(u => u.ListReservas).FirstOrDefault(u => u.UsuarioId == usuarioId);

        if (usuario == null)
        {
            throw new InvalidOperationException($"No se encontró ningún usuario con el Id {usuarioId}.");
        }

        var reserva = new Reserva
        {
            UsuarioId = reservaDTO.UsuarioId,
        };

        usuario.ListReservas.Add(reserva);
        SaveChanges();
    }

    public void AgregarDetalleReserva(int idReserva, int idObra, List<Asiento> asientos)
    {
        var reserva = _context.Reservas.FirstOrDefault(r => r.ReservaId == idReserva);
        var obra = _context.Obras.FirstOrDefault(o => o.ObraId == idObra);

        if (reserva == null || obra == null)
        {
            throw new InvalidOperationException("No se encontró la reserva o la obra especificada.");
        }

        var detalleReserva = new DetalleReserva
        {
            Reserva = reserva,
            Obra = obra,
            Asientos = asientos
        };

        _context.DetalleReservas.Add(detalleReserva);
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