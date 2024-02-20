using Microsoft.AspNetCore.Mvc;
using Teatro.Business;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ObraController : ControllerBase
{
    private readonly ILogger<ObraController> _logger;
    private readonly IObraServices _usuarioService;
    
    public ObraController(ILogger<ObraController> logger, IObraServices usuarioService)
    {
        _logger = logger;
        _usuarioService = usuarioService;
    }
}
