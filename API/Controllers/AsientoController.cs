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
    public ActionResult<List<Asiento>> GetAllObra() => _asientoService.GetAllAsiento();

    [HttpGet("{id}")]

    public ActionResult<Asiento> GetAsientoId(int id)
    {
        var obra = _asientoService.GetIdAsiento(id);
        _logger.LogInformation("peticion obra: " + id.ToString());
        if (obra == null)
            return NotFound();

        return obra;
    }

    [HttpPost()]
    public IActionResult CreateAsiento(Asiento asiento)
    {

        _asientoService.CreateAsiento(asiento);
        return Ok(asiento);

    }

    [HttpPut("{id}")]
    public IActionResult UpdateAsiento(int id, Asiento asiento)
    {

        if (id != asiento.AsientoId)
            return BadRequest();

        var existingAsiento = _asientoService.GetIdAsiento(id);

        if (existingAsiento is null)
            return NotFound();

        _asientoService.UpdateAsiento(asiento);

        return Ok(asiento);

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAsiento(int id)
    {

        var asiento = _asientoService.GetIdAsiento(id);

        if (asiento is null)
            return NotFound();

        _asientoService.DeleteAsiento(id);

        return Ok();

    }

}
