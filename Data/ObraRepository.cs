namespace Teatro.Data;

using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using Teatro.Models;

public class ObraRepository : IObraRepository
{
    private readonly TeatroContext _context;

    public ObraRepository(TeatroContext context)
    {
        _context = context;
    }


    public List<Obra> GetAllObras()
    {
        return _context.Obras.ToList();
    }

    public Obra GetIdObra(int IdObra)
    {
        var obra = _context.Obras.FirstOrDefault(p => p.ObraId == IdObra);

        if (obra is null)
        {
            throw new InvalidOperationException($"No se encontro la Obra con el id {IdObra}");
        }

        return obra;
    }

    public void CreateObra(Obra obra)
    {
        _context.Obras.Add(obra);
        SaveChanges();
    }

    public void UpdateObra(Obra obra)
    {
        var update = GetIdObra(obra.ObraId);

        if (update is null)
        {
            throw new KeyNotFoundException("No se encontro la obra a actualizar.");
        }

        _context.Entry(update).CurrentValues.SetValues(obra);
        SaveChanges();
    }

    public void DeleteObra(int idObra)
    {
        var obra = GetIdObra(idObra);

        if (obra is null)
        {
            throw new InvalidOperationException($"No se encontro la Obra con el id {idObra}");
        }

        var DetalleSala = _context.DetalleReservas.Where(ob => ob.ObraId == idObra);

        _context.DetalleReservas.RemoveRange(DetalleSala);
        _context.Obras.Remove(obra);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}