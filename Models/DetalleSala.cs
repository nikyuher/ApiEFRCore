namespace Teatro.Models;

public class DetalleSala
{
    public int DetalleSalaId { get; set; }

    public int SalaId { get; set; }
    public int ObraId { get; set; }

    public Sala? Sala { get; set; }
    public Obra? Obra { get; set; }

    public List<Asiento>? Asientos { get; set; }
}