namespace Teatro.Models;

public class ReservaGetDTO
{
    public int ReservaId { get; set; }

    public int UsuarioId { get; set; }

    public int ObraId { get; set; }
    public Obra? Obra { get; set; }

    public int AsientoId {get;set;}
    public Asiento? Asiento {get;set;}

}
