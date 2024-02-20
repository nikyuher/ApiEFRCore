using Microsoft.AspNetCore.Mvc;
using Teatro.Business;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private readonly IUsuarioServices _usuarioService;
    public UsuarioController(ILogger<UsuarioController> logger, IUsuarioServices usuarioService)
    {
        _logger = logger;
        _usuarioService = usuarioService;
    }
}
