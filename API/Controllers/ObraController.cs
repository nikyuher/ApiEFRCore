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
    public ActionResult<List<Obra>> GetAllObra() => _obraService.GetAllObras();

    [HttpGet("generos/{genero}")]
    public ActionResult<List<Obra>> GetAllGenero(string genero) => _obraService.GetAllGeneros(genero);

    [HttpGet("{id}")]
    public ActionResult<Obra> GetObraId(int id)
    {
        var obra = _obraService.GetIdObra(id);
        _logger.LogInformation("peticion obra: " + id.ToString());
        if (obra == null)
            return NotFound();

        return obra;
    }

    [HttpPost()]
    public IActionResult CreateObra(Obra obra)
    {
        _obraService.CreateObra(obra);
        return Ok(obra);
    }

    [HttpPut("{id}")]
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

    [HttpDelete("{id}")]
    public IActionResult DeleteObra(int id)
    {
        var obra = _obraService.GetIdObra(id);

        if (obra is null)
            return NotFound();

        _obraService.DeleteObra(id);

        return Ok();
    }

}
