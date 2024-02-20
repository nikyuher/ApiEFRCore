namespace Teatro.Data;

using Teatro.Models;

public class UsuarioEFRepository : IUsuarioRepository
{
    private readonly TeatroContext _context;

    public UsuarioEFRepository(TeatroContext context)
    {
        _context = context;
    }

    public List<Usuario> GetAllUsuarios()
    {
        return _context.Usuarios.ToList();
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

    public void CreateUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
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

    public void DeleteUsuario(int idUsuario)
    {
        var usuario = GetIdUsuario(idUsuario);

        if (usuario is null)
        {
            throw new InvalidOperationException($"No se encontro el Usuario con el id {idUsuario}");
        }

        var reserva = _context.Reservas.Where(r => r.UsuarioId == idUsuario);

        _context.Reservas.RemoveRange(reserva);
        _context.Usuarios.Remove(usuario);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}