using Microsoft.AspNetCore.Identity;
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
    private readonly IUsuarioServices _usuarioService;

    public TeatrumApiController(ILogger<TeatrumApiController> logger, IObraServices obraService, IUsuarioServices usuarioService)
    {
        _logger = logger;
        _obraService = obraService;
        _usuarioService = usuarioService;
    }


    //Obras
    [HttpGet("obras")]
    public ActionResult<List<Obra>> GetAllObra() => _obraService.GetAllObras();

    [HttpGet("obras/{id}")]

    public ActionResult<Obra> GetObraId(int id)
    {
        var obra = _obraService.GetIdObra(id);

        if (obra == null)
            return NotFound();

        return obra;
    }

    [HttpPost("obras/create")]
    public IActionResult CreateObra(Obra obra)
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
    public IActionResult DeleteObra(int id)
    {
        var obra = _obraService.GetIdObra(id);

        if (obra is null)
            return NotFound();

        _obraService.DeleteObra(id);

        return Ok();
    }

    //Usuario

    [HttpGet("usuarios")]
    public ActionResult<List<UsuarioGetDTO>> GetAllUsuario() => _usuarioService.GetAllUsuarios();

    [HttpGet("usuarios/{id}")]

    public ActionResult<UsuarioGetDTO> GetUsuarioId(int id)
    {
        var user = _usuarioService.GetIdUsuario(id);

        if (user == null)
            return NotFound();

        return user;
    }

    [HttpPost("usuarios/create")]
    public IActionResult CreateUsuario(UsuarioAddDTO user)
    {
        _usuarioService.CreateUsuario(user);
        return Ok(user);
    }

    [HttpPut("usuarios/update")]
    public IActionResult UpdateUsuario(int id, UsuarioPutDTO user)
    {

        if (id != user.UsuarioId)
            return BadRequest();

        var existingUser = _usuarioService.GetIdUsuario(id);

        if (existingUser is null)
            return NotFound();

        _usuarioService.UpdateUsuario(user);

        return Ok(user);

    }

    [HttpDelete("usuarios/delete/{id}")]
    public IActionResult DeleteUsuario(int id)
    {
        var user = _usuarioService.GetIdUsuario(id);

        if (user is null)
            return NotFound();

        _usuarioService.DeleteUsuario(id);

        return Ok();
    }

    //Reserva

    [HttpGet("usuarios/reservas")]
    public ActionResult<List<Reserva>> GetAllReserva() => _usuarioService.GetAllReservas();

    [HttpGet("usuarios/{id}/reservas")]

    public ActionResult<List<Reserva>> GetReservasUsuario(int id)
    {
        var reserva = _usuarioService.GetReservasUsuario(id);

        if (reserva == null)
            return NotFound();

        return reserva;
    }

    [HttpPost("usuarios/create/reservas/{IdUser}")]
    public IActionResult CreateReserva(int IdUser, Reserva reserva)
    {


        _usuarioService.CreateReserva(IdUser, reserva);
        return Ok(reserva);
    }

    [HttpPut("usuarios/update/reservas")]
    public IActionResult UpdateReserva(int id, Reserva reserva)
    {

        var existingUser = _usuarioService.GetIdUsuario(id);

        if (existingUser is null)
            return NotFound();

        _usuarioService.UpdateReserva(reserva);

        return Ok(reserva);

    }

    [HttpDelete("usuarios/delete/reservas/{id}")]
    public IActionResult DeleteReserva(int id)
    {
        var user = _usuarioService.GetIdReserva(id);

        if (user is null)
            return NotFound();

        _usuarioService.DeleteReserva(id);

        return Ok();
    }


    [HttpPost("usuario/reserva/detalle")]
    public IActionResult AgregarDetalle(int idReserva, int idObra, List<Asiento> asientos)
    {
      _obraService.AgregarDetalleReserva(idReserva,idObra,asientos);

        return Ok();
    }
}
