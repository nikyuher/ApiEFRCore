using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Teatro.Business;
using Teatro.Models;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservaController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private readonly IReservaServices _reservaService;

    public ReservaController(ILogger<UsuarioController> logger, IReservaServices usuarioService)
    {
        _logger = logger;
        _reservaService = usuarioService;
    }

    [HttpGet()]
    public ActionResult<List<ReservaGetDTO>> GetAllReserva()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todas las reservas.");
            return _reservaService.GetAllReservas();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todas las reservas: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("usuario")]

    public ActionResult<List<ReservaGetDTO>> GetReservasUsuario(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener las reservas del usuario con ID: {id}.");
            var reservas = _reservaService.GetReservasUsuario(id);

            if (reservas == null)
            {
                _logger.LogWarning($"No se encontraron reservas para el usuario con ID: {id}.");
                return NotFound();
            }

            return reservas;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener las reservas del usuario con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
    
    [HttpPost()]
    public IActionResult CreateReserva([FromBody] List<ReservaAddDTO> user)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de reservas.");
            _reservaService.CreateReservas(user);
            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear reservas: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut()]
    public IActionResult UpdateReserva(int id, [FromBody] ReservaPutDTO reserva)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización de la reserva con ID: {id}.");

            var existingReserva = _reservaService.GetIdReserva(id);

            if (existingReserva is null)
            {
                _logger.LogWarning($"No se encontró ninguna reserva con ID: {id}.");
                return NotFound();
            }

            _reservaService.UpdateReserva(reserva);

            return Ok(reserva);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar la reserva con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete()]
    public IActionResult DeleteReserva(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar la reserva con ID: {id}.");

            var reserva = _reservaService.GetIdReserva(id);

            if (reserva is null)
            {
                _logger.LogWarning($"No se encontró ninguna reserva con ID: {id}.");
                return NotFound();
            }

            _reservaService.DeleteReserva(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar la reserva con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
}
