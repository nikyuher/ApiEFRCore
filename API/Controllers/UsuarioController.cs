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

    [HttpPost("login")]
    public IActionResult Login([FromBody] UsuarioLoginDTO loginRequest)
    {
        try
        {
            var usuario = _usuarioService.Login(loginRequest);

            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    

    [HttpPost("register")]
    public IActionResult CreateUsuario([FromBody] UsuarioAddDTO user)
    {
        try
        {
            _usuarioService.CreateUsuario(user);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUsuario(int id , [FromBody] UsuarioPutDTO user)
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
