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
        var reservas = _context.Reservas.Include(r => r.Obra).Include(r => r.Asiento).ToList();

        var reservasDTO = reservas.Select(reserva =>
            new ReservaGetDTO
            {
                ReservaId = reserva.ReservaId,
                UsuarioId = reserva.UsuarioId,
                ObraId = reserva.ObraId,
                Obra = reserva.Obra,
                AsientoId = reserva.AsientoId,
                Asiento = reserva.Asiento
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
                            .Where(r => r.UsuarioId == usuarioId)
                            .Select(r => new ReservaGetDTO
                            {
                                ReservaId = r.ReservaId,
                                UsuarioId = r.UsuarioId,
                                ObraId = r.ObraId,
                                Obra = r.Obra,
                                AsientoId = r.AsientoId,
                                Asiento = r.Asiento
                            })
                            .ToList();
        return reservasDTO;
    }

    public void CreateReserva(ReservaAddDTO reservaDTO)
    {
        var usuario = _context.Usuarios.Include(u => u.ListReservas).FirstOrDefault(u => u.UsuarioId == reservaDTO.UsuarioId);
        var obra = _context.Obras.FirstOrDefault(o => o.ObraId == reservaDTO.ObraId);
        var asiento = _context.Asientos.FirstOrDefault(a => a.AsientoId == reservaDTO.AsientoId);

        if (usuario == null || obra == null || asiento == null)
        {
            throw new InvalidOperationException($"No se encontró el usuario, la obra o el asiento especificado.");
        }

        var reserva = new Reserva
        {
            UsuarioId = reservaDTO.UsuarioId,
            Obra = obra,
            Asiento = asiento
        };

        usuario.ListReservas.Add(reserva);
        _context.SaveChanges();
    }


    public void UpdateReserva(ReservaPutDTO reservaDTO)
    {
        var reserva = GetIdReserva(reservaDTO.ReservaId);

        if (reserva == null)
        {
            throw new KeyNotFoundException($"No se encontró la reserva con el ID {reservaDTO.ReservaId}.");
        }

        var obra = _context.Obras.FirstOrDefault(o => o.ObraId == reservaDTO.ObraId);
        var asiento = _context.Asientos.FirstOrDefault(a => a.AsientoId == reservaDTO.AsientoId);

        if (obra == null || asiento == null)
        {
            throw new InvalidOperationException("No se encontró la obra o el asiento especificado.");
        }

        reserva.Obra = obra;
        reserva.Asiento = asiento;

        _context.SaveChanges();
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