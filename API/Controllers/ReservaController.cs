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
    public ActionResult<List<ReservaGetDTO>> GetAllReserva() => _reservaService.GetAllReservas();

    [HttpGet("usuario/{id}")]

    public ActionResult<List<ReservaGetDTO>> GetReservasUsuario(int id)
    {

        var reserva = _reservaService.GetReservasUsuario(id);

        if (reserva == null)
            return NotFound();

        return reserva;

    }

    [HttpPost("{IdUser}")]
    public IActionResult CreateReserva(ReservaAddDTO reserva)
    {
        try
        {
            _reservaService.CreateReserva(reserva);
            return Ok(reserva);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateReserva(int id, ReservaPutDTO reserva)
    {

        var existingUser = _reservaService.GetIdReserva(id);

        if (existingUser is null)
            return NotFound();

        _reservaService.UpdateReserva(reserva);

        return Ok(reserva);

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteReserva(int id)
    {

        var user = _reservaService.GetIdReserva(id);

        if (user is null)
            return NotFound();

        _reservaService.DeleteReserva(id);

        return Ok();
    }
}
