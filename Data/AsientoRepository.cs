namespace Teatro.Data;

using Microsoft.EntityFrameworkCore;
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

    public Asiento GetIdAsiento(int idAsiento)
    {
        var obra = _context.Asientos.FirstOrDefault(p => p.AsientoId == idAsiento);

        if (obra is null)
        {
            throw new InvalidOperationException($"No se encontro el Asiento con el id {idAsiento}");
        }

        return obra;
    }

    public void CreateAsiento(Asiento asiento)
    {
        _context.Asientos.Add(asiento);
        SaveChanges();
    }

    public void AgregarAsientoAObra(int idAsiento, int idObra)
    {
        // Busca el asiento por su ID
        var asiento = GetIdAsiento(idAsiento);

        if (asiento is null)
        {
            throw new InvalidOperationException($"No se encontró el Asiento con el ID {idAsiento}");
        }

        // Busca la obra por su ID
        var obra = _context.Obras.Include(o => o.ObrasAsientos).FirstOrDefault(o => o.ObraId == idObra);

        if (obra is null)
        {
            throw new InvalidOperationException($"No se encontró la Obra con el ID {idObra}");
        }

        // Crea una nueva instancia de ObraAsiento con los datos del asiento modificado
        var nuevaObraAsiento = new ObraAsiento
        {
            AsientoId = asiento.AsientoId,
            Asiento = asiento,
            ObraId = obra.ObraId
        };

        // Agrega la nueva instancia de ObraAsiento a la lista de ObrasAsientos de la Obra
        obra.ObrasAsientos.Add(nuevaObraAsiento);

        SaveChanges();
    }

    public void UpdateAsiento(Asiento asiento)
    {
        var update = GetIdAsiento(asiento.AsientoId);

        if (update is null)
        {
            throw new KeyNotFoundException("No se encontro el Asiento a actualizar.");
        }

        _context.Entry(update).CurrentValues.SetValues(asiento);
        SaveChanges();
    }

    public void UpdateEstado(AsientoPutEstadoDTO asiento)
    {
        var update = GetIdAsiento(asiento.AsientoId);

        if (update is null)
        {
            throw new KeyNotFoundException("No se encontro el Asiento a actualizar.");
        }

        update.Estado = asiento.Estado;

        SaveChanges();
    }

    public void DeleteAsiento(int idAsiento)
    {
        var asiento = GetIdAsiento(idAsiento);

        if (asiento is null)
        {
            throw new InvalidOperationException($"No se encontro el Asiento con el id {idAsiento}");
        }

        _context.Asientos.Remove(asiento);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}