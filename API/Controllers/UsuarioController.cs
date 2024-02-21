using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Teatro.Business;
using Teatro.Models;

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

    [HttpGet()]
    public ActionResult<List<UsuarioGetDTO>> GetAllUsuario() => _usuarioService.GetAllUsuarios();

    [HttpGet("{id}")]

    public ActionResult<UsuarioGetDTO> GetUsuarioId(int id)
    {
        var user = _usuarioService.GetIdUsuario(id);

        if (user == null)
            return NotFound();

        return user;
    }

    [HttpPost()]
    public IActionResult CreateUsuario(UsuarioAddDTO user)
    {
        _usuarioService.CreateUsuario(user);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUsuario(int id, UsuarioPutDTO user)
    {

        if (id != user.UsuarioId)
            return BadRequest();

        var existingUser = _usuarioService.GetIdUsuario(id);

        if (existingUser is null)
            return NotFound();

        _usuarioService.UpdateUsuario(user);

        return Ok(user);

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUsuario(int id)
    {
        var user = _usuarioService.GetIdUsuario(id);

        if (user is null)
            return NotFound();

        _usuarioService.DeleteUsuario(id);

        return Ok();
    }

}
