namespace Teatro.Data;

public class UsuarioEFRepository : IUsuarioRepository
{
    private readonly TeatroContext _context;

    public UsuarioEFRepository(TeatroContext context)
    {
        _context = context;
    }


}