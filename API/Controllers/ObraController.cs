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
    public ActionResult<List<ObraGetDTO>> GetAllGenero(string genero) => _obraService.GetAllGeneros(genero);

    [HttpGet("{id}/asientos")]
    public ActionResult<ObraGetAsientosDTO> GetAsientosObra(int id)
    {
        var asientos = _obraService.GetAsientosObra(id);

        if (asientos == null)
        {
            return NotFound();
        }

        return Ok(asientos);
    }


    [HttpGet("{id}")]
    public ActionResult<ObraGetDTO> GetObraId(int id)
    {

        var obra = _obraService.GetIdObra(id);
        _logger.LogInformation("peticion obra: " + id.ToString());
        if (obra == null)
            return NotFound();

        return obra;

    }

    [HttpPost()]
    public IActionResult CreateObra(ObraAddDTO obra)
    {

        _obraService.CreateObra(obra);
        return Ok(obra);

    }

    [HttpPut("{id}")]
    public IActionResult UpdateObra(int id, Obra obra)
    {

        try
        {
            if (id != obra.ObraId)
                return BadRequest();

            var existingObra = _obraService.GetIdObra(id);

            if (existingObra is null)
                return NotFound();

            _obraService.UpdateObra(obra);

            return Ok(obra);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

    }

    [HttpPut("img/{id}")]
    public IActionResult UpdateObraImg(int id, ObraPutImgDTO obra)
    {

        if (id != obra.ObraId)
            return BadRequest();

        var existingObra = _obraService.GetIdObra(id);

        if (existingObra is null)
            return NotFound();

        _obraService.UpdateObraImg(obra);

        return Ok(obra);

    }

    [HttpPut("info/{id}")]
    public IActionResult UpdateObraInfo(int id, ObraPutInfoDTO obra)
    {

        if (id != obra.ObraId)
            return BadRequest();

        var existingObra = _obraService.GetIdObra(id);

        if (existingObra is null)
            return NotFound();

        _obraService.UpdateObraInfo(obra);

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
