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
    public ActionResult<List<UsuarioGetDTO>> GetAllUsuario()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos los usuarios.");
            return _usuarioService.GetAllUsuarios();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los usuarios: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("{id}")]

    public ActionResult<UsuarioGetDTO> GetUsuarioId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el usuario con ID: {id}.");

            var user = _usuarioService.GetIdUsuario(id);

            if (user == null)
            {
                _logger.LogWarning($"No se encontró ningún usuario con ID: {id}.");
                return NotFound();
            }

            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener el usuario con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UsuarioLoginDTO loginRequest)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de inicio de sesión.");

            var usuario = _usuarioService.Login(loginRequest);

            return Ok(usuario);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar iniciar sesión: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }


    [HttpPost("register")]
    public IActionResult CreateUsuario([FromBody] UsuarioAddDTO user)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de usuario.");

            _usuarioService.CreateUsuario(user);
            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear usuario: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateUsuario(int id, [FromBody] UsuarioPutDTO user)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización del usuario con ID: {id}.");

            if (id != user.UsuarioId)
            {
                _logger.LogError("El ID del usuario en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingUser = _usuarioService.GetIdUsuario(id);

            if (existingUser is null)
            {
                _logger.LogWarning($"No se encontró ningún usuario con ID: {id}.");
                return NotFound();
            }

            _usuarioService.UpdateUsuario(user);

            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar usuario con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUsuario(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar el usuario con ID: {id}.");

            var user = _usuarioService.GetIdUsuario(id);

            if (user is null)
            {
                _logger.LogWarning($"No se encontró ningún usuario con ID: {id}.");
                return NotFound();
            }

            _usuarioService.DeleteUsuario(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar usuario con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

}
