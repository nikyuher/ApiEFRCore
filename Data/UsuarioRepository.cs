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
        var usuarios = _context.Usuarios.ToList();

        var usuariosDTO = usuarios.Select(usuario => new UsuarioGetDTO
        {
            UsuarioId = usuario.UsuarioId,
            Rol = usuario.Rol,
            Nombre = usuario.Nombre,
            CorreoElectronico = usuario.CorreoElectronico
        }).ToList();

        return usuariosDTO;
    }


    public UsuarioGetDTO GetIdUsuarioDTO(int idUsuario)
    {
        var usuario = _context.Usuarios
                                .Include(u => u.ListReservas)
                                    .ThenInclude(r => r.Obra)
                                .FirstOrDefault(u => u.UsuarioId == idUsuario);

        if (usuario is null)
        {
            throw new InvalidOperationException($"No se encontró al usuario con el ID {idUsuario}");
        }

        var usuarioDTO = new UsuarioGetDTO
        {
            UsuarioId = usuario.UsuarioId,
            Nombre = usuario.Nombre,
            CorreoElectronico = usuario.CorreoElectronico
        };

        return usuarioDTO;
    }


    public Usuario Login(UsuarioLoginDTO loginDTO)
    {
        if (string.IsNullOrWhiteSpace(loginDTO.CorreoElectronico))
        {
            throw new ArgumentException("El correo electrónico no puede estar vacío", nameof(loginDTO.CorreoElectronico));
        }

        if (string.IsNullOrWhiteSpace(loginDTO.Contraseña))
        {
            throw new ArgumentException("La contraseña no puede estar vacía", nameof(loginDTO.Contraseña));
        }

        var usuario = _context.Usuarios.FirstOrDefault(u => u.CorreoElectronico == loginDTO.CorreoElectronico && u.Contraseña == loginDTO.Contraseña);

        if (usuario is null)
        {
            throw new InvalidOperationException("Credenciales incorrectas");
        }

        return usuario;
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