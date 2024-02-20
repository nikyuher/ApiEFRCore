namespace Teatro.Business;

using Teatro.Data;
public class UsuarioServices : IUsuarioServices
{

    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioServices(IUsuarioRepository repository)
    {
        _usuarioRepository = repository;
    }

}
