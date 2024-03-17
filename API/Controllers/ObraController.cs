using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Teatro.Business;
using Teatro.Models;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ObraController : ControllerBase
{
    private readonly ILogger<ObraController> _logger;
    private readonly IObraServices _obraService;

    public ObraController(ILogger<ObraController> logger, IObraServices obraService)
    {
        _logger = logger;
        _obraService = obraService;
    }

    [HttpGet()]
    public ActionResult<List<Obra>> GetAllObra()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todas las obras.");
            return _obraService.GetAllObras();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todas las obras: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("search")]
    public  ActionResult<List<ObraGetDTO>> GetObrasTitulo(string titulo)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado buscar obras por el título: {titulo}.");

            var obras = _obraService.BuscarPorTitulo(titulo);

            if (obras == null || obras.Count == 0)
            {
                _logger.LogWarning($"No se encontraron obras con el título: {titulo}.");
                return NotFound();
            }

            return Ok(obras);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar buscar obras por título {titulo}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("generos")]
    public ActionResult<List<ObraGetDTO>> GetAllGenero(string genero)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener todas las obras del género: {genero}.");
            return _obraService.GetAllGeneros(genero);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todas las obras del género {genero}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("{id}/asientos")]
    public ActionResult<ObraGetAsientosDTO> GetAsientosObra(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener los asientos de la obra con ID: {id}.");
            var asientos = _obraService.GetAsientosObra(id);

            if (asientos == null)
            {
                _logger.LogWarning($"No se encontraron asientos para la obra con ID: {id}.");
                return NotFound();
            }

            return Ok(asientos);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener los asientos de la obra con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }


    [HttpGet("{id}")]
    public ActionResult<ObraGetDTO> GetObraId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener la obra con ID: {id}.");
            var obra = _obraService.GetIdObra(id);

            if (obra == null)
            {
                _logger.LogWarning($"No se encontró ninguna obra con ID: {id}.");
                return NotFound();
            }

            return obra;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener la obra con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPost()]
    public IActionResult CreateObra([FromBody] ObraAddDTO obra)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de obra.");
            _obraService.CreateObra(obra);
            return Ok(obra);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear la obra: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut()]
    public IActionResult UpdateObra(int id, [FromBody] Obra obra)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización de la obra con ID: {id}.");

            if (id != obra.ObraId)
            {
                _logger.LogError("El ID de la obra en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingObra = _obraService.GetIdObra(id);

            if (existingObra is null)
            {
                _logger.LogWarning($"No se encontró ninguna obra con ID: {id}.");
                return NotFound();
            }

            _obraService.UpdateObra(obra);

            return Ok(obra);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar la obra con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPut("img")]
    public IActionResult UpdateObraImg(int id, [FromBody] ObraPutImgDTO obra)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización de la imagen de la obra con ID: {id}.");

            if (id != obra.ObraId)
            {
                _logger.LogError("El ID de la obra en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingObra = _obraService.GetIdObra(id);

            if (existingObra is null)
            {
                _logger.LogWarning($"No se encontró ninguna obra con ID: {id}.");
                return NotFound();
            }

            _obraService.UpdateObraImg(obra);

            return Ok(obra);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar la imagen de la obra con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPut("info")]
    public IActionResult UpdateObraInfo(int id, [FromBody] ObraPutInfoDTO obra)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización de la información de la obra con ID: {id}.");

            if (id != obra.ObraId)
            {
                _logger.LogError("El ID de la obra en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingObra = _obraService.GetIdObra(id);

            if (existingObra is null)
            {
                _logger.LogWarning($"No se encontró ninguna obra con ID: {id}.");
                return NotFound();
            }

            _obraService.UpdateObraInfo(obra);

            return Ok(obra);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar la información de la obra con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete()]
    public IActionResult DeleteObra(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar la obra con ID: {id}.");

            var obra = _obraService.GetIdObra(id);

            if (obra is null)
            {
                _logger.LogWarning($"No se encontró ninguna obra con ID: {id}.");
                return NotFound();
            }

            _obraService.DeleteObra(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar la obra con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

}
