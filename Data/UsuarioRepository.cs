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

    public UsuarioGetLoginDTO GetLogin(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("El correo electrónico no puede estar vacío", nameof(email));
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("La contraseña no puede estar vacía", nameof(password));
        }

        var usuario = _context.Usuarios.FirstOrDefault(u => u.CorreoElectronico == email && u.Contraseña == password);

        if (usuario is null)
        {
            throw new InvalidOperationException("Credenciales incorrectas");
        }

        var usuarioLoginDTO = new UsuarioGetLoginDTO
        {
            UsuarioId = usuario.UsuarioId,
            Rol = usuario.Rol,
            Nombre = usuario.Nombre
        };

        return usuarioLoginDTO;
    }

    public UsuarioGetDTO Login(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("El correo electrónico no puede estar vacío", nameof(email));
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("La contraseña no puede estar vacía", nameof(password));
        }

        var usuario = _context.Usuarios.FirstOrDefault(u => u.CorreoElectronico == email && u.Contraseña == password);

        if (usuario is null)
        {
            throw new InvalidOperationException("Credenciales incorrectas");
        }

        var usuarioDTO = new UsuarioGetDTO
        {
            CorreoElectronico = usuario.CorreoElectronico,
            Contraseña = usuario.Contraseña,
        };

        return usuarioDTO;
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
            throw new KeyNotFoundException("No se encontró el Usuario a actualizar.");
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