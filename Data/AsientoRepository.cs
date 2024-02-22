namespace Teatro.Data;

using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using Teatro.Models;

public class AsientoRepository : IAsientoRepository
{
    private readonly TeatroContext _context;

    public AsientoRepository(TeatroContext context)
    {
        _context = context;
    }


    public List<Asiento> GetAllAsiento()
    {
        return _context.Asientos.ToList();
    }

    public Asiento GetIdAsiento(int IdObra)
    {
        var obra = _context.Asientos.FirstOrDefault(p => p.AsientoId == IdObra);

        if (obra is null)
        {
            throw new InvalidOperationException($"No se encontro la Obra con el id {IdObra}");
        }

        return obra;
    }

    public void CreateAsiento(Asiento obra)
    {
        _context.Asientos.Add(obra);
        SaveChanges();
    }

    public void UpdateAsiento(Asiento asiento)
    {
        var update = GetIdAsiento(asiento.AsientoId);

        if (update is null)
        {
            throw new KeyNotFoundException("No se encontro la obra a actualizar.");
        }

        _context.Entry(update).CurrentValues.SetValues(asiento);
        SaveChanges();
    }

    public void DeleteAsiento(int idAsiento)
    {
        var asiento = GetIdAsiento(idAsiento);

        if (asiento is null)
        {
            throw new InvalidOperationException($"No se encontro la Obra con el id {idAsiento}");
        }

        var DetalleSala = _context.Reservas.Where(ob => ob.AsientoId == idAsiento);

        _context.Reservas.RemoveRange(DetalleSala);
        _context.Asientos.Remove(asiento);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}