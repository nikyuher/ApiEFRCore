namespace Teatro.Data;

using Microsoft.EntityFrameworkCore;
using Teatro.Models;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly TeatroContext _context;

    public UsuarioRepository(TeatroContext context)
    {
        _context = context;
    }

    public List<UsuarioGetDTO> GetAllUsuarios()
    {
        var usuarios = _context.Usuarios
                            .Include(u => u.ListReservas)
                                .ThenInclude(r => r.Obra)
                            .Include(u => u.ListReservas)
                                .ThenInclude(r => r.Asiento)
                            .ToList();

        var usuariosDTO = usuarios.Select(usuario => new UsuarioGetDTO
        {
            UsuarioId = usuario.UsuarioId,
            Rol = usuario.Rol,
            Nombre = usuario.Nombre,
            CorreoElectronico = usuario.CorreoElectronico,
            Contraseña = usuario.Contraseña,
            ListReservas = usuario.ListReservas
        }).ToList();

        return usuariosDTO;
    }


    public UsuarioGetDTO GetIdUsuarioDTO(int idUsuario)
    {
        var usuario = _context.Usuarios
                                .Include(u => u.ListReservas)
                                    .ThenInclude(r => r.Obra)
                                .Include(u => u.ListReservas)
                                    .ThenInclude(r => r.Asiento)
                                .FirstOrDefault(u => u.UsuarioId == idUsuario);

        if (usuario is null)
        {
            throw new InvalidOperationException($"No se encontró al usuario con el ID {idUsuario}");
        }

        var usuarioDTO = new UsuarioGetDTO
        {
            UsuarioId = usuario.UsuarioId,
            Nombre = usuario.Nombre,
            CorreoElectronico = usuario.CorreoElectronico,
            Contraseña = usuario.Contraseña,
            ListReservas = usuario.ListReservas
        };

        return usuarioDTO;
    }

    public UsuarioGetRegisterDTO GetRegisterUsuario(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("El correo electrónico no puede estar vacío", nameof(email));
        }

        if (!ValidacionEmail(email))
        {
            throw new ArgumentException("El formato del correo electrónico no es válido", nameof(email));
        }

        var user = _context.Usuarios.FirstOrDefault(u => u.CorreoElectronico == email);

        if (user is null)
        {
            throw new InvalidOperationException($"No se encontro usuario con el Email: {email}");
        }

        var usuarioDTO = new UsuarioGetRegisterDTO
        {
            UsuarioId = user.UsuarioId,
            Nombre = user.Nombre,
            CorreoElectronico = user.CorreoElectronico,
            Contraseña = user.Contraseña
        };

        return usuarioDTO;
    }

    private bool ValidacionEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
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

    public void UpdateUsuario(UsuarioPutDTO usuarioDto)
    {
        var usuario = GetIdUser(usuarioDto.UsuarioId);

        if (usuario is null)
        {
            throw new KeyNotFoundException("No se encontró el usuario a actualizar.");
        }

        usuario.Nombre = usuarioDto.Nombre;
        usuario.CorreoElectronico = usuarioDto.CorreoElectronico;
        usuario.Contraseña = usuarioDto.Contraseña;

        SaveChanges();
    }

    public void DeleteUsuario(int idUsuario)
    {
        var usuario = GetIdUser(idUsuario);

        if (usuario is null)
        {
            throw new InvalidOperationException($"No se encontro el Usuario con el id {idUsuario}");
        }

        _context.Usuarios.Remove(usuario);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}