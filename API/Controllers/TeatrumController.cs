using Microsoft.AspNetCore.Mvc;
using Teatro.Business;
using Teatro.Models;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TeatrumApiController : ControllerBase
{
    private readonly ILogger<TeatrumApiController> _logger;
    private readonly IObraServices _obraService;

    public TeatrumApiController(ILogger<TeatrumApiController> logger, IObraServices obraService)
    {
        _logger = logger;
        _obraService = obraService;
    }

    [HttpGet("obras")]
    public ActionResult<List<Obra>> GetAllObra() => _obraService.GetAllObras();

    [HttpGet("obras/{id}")]

    public ActionResult<Obra> GetPizzaId(int id)
    {
        var obra = _obraService.GetIdObra(id);

        if (obra == null)
            return NotFound();

        return obra;
    }

    [HttpPost("obras/create")]
    public IActionResult CreatePizza(Obra obra)
    {
        _obraService.CreateObra(obra);
        return Ok(obra);
    }

    [HttpPut("obras/update")]
    public IActionResult UpdateObra(int id, Obra obra)
    {

        if (id != obra.ObraId)
            return BadRequest();

        var existingObra = _obraService.GetIdObra(id);

        if (existingObra is null)
            return NotFound();

        _obraService.UpdateObra(obra);

        return Ok(obra);

    }

    [HttpDelete("obras/delete/{id}")]
    public IActionResult DeletePizza(int id)
    {
        var obra = _obraService.GetIdObra(id);

        if (obra is null)
            return NotFound();

        _obraService.DeleteObra(id);

        return Ok();
    }
}
