namespace Teatro.Data;

using Microsoft.EntityFrameworkCore;
using Teatro.Models;

public class UsuarioEFRepository : IUsuarioRepository
{
    private readonly TeatroContext _context;

    public UsuarioEFRepository(TeatroContext context)
    {
        _context = context;
    }

    public List<UsuarioGetDTO> GetAllUsuarios()
    {
        var usuarios = _context.Usuarios
                        .Include(p => p.ListReservas)
                            .ThenInclude(pi => pi.Detalles)
                        .ToList();

        var usuariosDTO = usuarios.Select(usuario => new UsuarioGetDTO
        {
            UsuarioId = usuario.UsuarioId,
            Nombre = usuario.Nombre,
            CorreoElectronico = usuario.CorreoElectronico,
            Contraseña = usuario.Contraseña,
            ListReservas = usuario.ListReservas 
        }).ToList();

        return usuariosDTO;
    }

    public List<Reserva> GetAllReservas()
    {
        return _context.Reservas.Include(p => p.Detalles).ToList();
    }

    public Usuario GetIdUsuario(int idUsuario)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == idUsuario);

        if (usuario is null)
        {
            throw new InvalidOperationException($"No se encontro al usuario con el ID {idUsuario}");
        }

        return usuario;
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

    public List<Reserva> GetReservasUsuario(int usuarioId)
    {
        var usuario = _context.Usuarios.Include(u => u.ListReservas).FirstOrDefault(u => u.UsuarioId == usuarioId);

        if (usuario == null)
        {
            throw new InvalidOperationException($"No se encontró ningún usuario con el Id {usuarioId}.");
        }

        return usuario.ListReservas.ToList();
    }


    public void CreateUsuario(UsuarioAddDTO usuarioDto)
    {
        var usuario = new Usuario
        {
            Nombre = usuarioDto.Nombre,
            CorreoElectronico = usuarioDto.CorreoElectronico,
            Contraseña = usuarioDto.Contraseña
        };

        _context.Usuarios.Add(usuario);
        SaveChanges();
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
    
    public void UpdateUsuario(Usuario usuario)
    {
        var update = GetIdUsuario(usuario.UsuarioId);

        if (update is null)
        {
            throw new KeyNotFoundException("No se encontro la obra a actualizar.");
        }

        _context.Entry(update).CurrentValues.SetValues(usuario);
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

    public void DeleteUsuario(int idUsuario)
    {
        var usuario = GetIdUsuario(idUsuario);

        if (usuario is null)
        {
            throw new InvalidOperationException($"No se encontro el Usuario con el id {idUsuario}");
        }

        _context.Usuarios.Remove(usuario);
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