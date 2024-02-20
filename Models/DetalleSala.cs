namespace Teatro.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class DetalleSala
{
    public int SalaId { get; set; }
    public int ObraId { get; set; }

    public Sala? Sala { get; set; }
    public Obra? Obra { get; set; }

    public List<Asiento> Asientos { get; set; } = new List<Asiento>();
}