using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Teatro.Business;
using Teatro.Models;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AsientoController : ControllerBase
{
    private readonly ILogger<AsientoController> _logger;
    private readonly IAsientoServices _asientoService;

    public AsientoController(ILogger<AsientoController> logger, IAsientoServices asientoService)
    {
        _logger = logger;
        _asientoService = asientoService;
    }

    [HttpGet()]
    public ActionResult<List<Asiento>> GetAllObra()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos los asientos.");
            return _asientoService.GetAllAsiento();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los asientos: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("estado/{estado}")]
    public ActionResult<List<Asiento>> GetAllEstado(bool estado)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener todos los asientos con estado: {estado}.");
            return _asientoService.GetAsientoEstado(estado);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los asientos con estado {estado}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Asiento> GetAsientoId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el asiento con ID: {id}.");
            var asiento = _asientoService.GetIdAsiento(id);

            if (asiento == null)
            {
                _logger.LogWarning($"No se encontró ningún asiento con ID: {id}.");
                return NotFound();
            }

            return asiento;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener el asiento con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPost()]
    public IActionResult CreateAsiento([FromBody] Asiento asiento)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de asiento.");
            _asientoService.CreateAsiento(asiento);
            return Ok(asiento);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear el asiento: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("ocupados")]
    public IActionResult AgregarAsientoAObra([FromBody] List<AsientoOcupadoDTO> ocupadoDTO)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud para agregar asientos a una obra.");
            _asientoService.AgregarAsientoAObra(ocupadoDTO);
            return Ok("Asientos agregados exitosamente a la obra.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar agregar asientos a la obra: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAsiento(int id, [FromBody] Asiento asiento)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización del asiento con ID: {id}.");

            if (id != asiento.AsientoId)
            {
                _logger.LogError("El ID del asiento en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingAsiento = _asientoService.GetIdAsiento(id);

            if (existingAsiento == null)
            {
                _logger.LogWarning($"No se encontró ningún asiento con ID: {id}.");
                return NotFound();
            }

            _asientoService.UpdateAsiento(asiento);
            return Ok(asiento);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar el asiento con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPut("{id}/estado")]
    public IActionResult UpdateEstado(int id, [FromBody] AsientoPutEstadoDTO asiento)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización del estado del asiento con ID: {id}.");

            if (id != asiento.AsientoId)
            {
                _logger.LogError("El ID del asiento en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingAsiento = _asientoService.GetIdAsiento(id);

            if (existingAsiento == null)
            {
                _logger.LogWarning($"No se encontró ningún asiento con ID: {id}.");
                return NotFound();
            }

            _asientoService.UpdateEstado(asiento);
            return Ok(asiento);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar el estado del asiento con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAsiento(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar el asiento con ID: {id}.");

            var asiento = _asientoService.GetIdAsiento(id);

            if (asiento == null)
            {
                _logger.LogWarning($"No se encontró ningún asiento con ID: {id}.");
                return NotFound();
            }

            _asientoService.DeleteAsiento(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar el asiento con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

}
