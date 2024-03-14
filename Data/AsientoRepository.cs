namespace Teatro.Data;

using System.Reflection.Metadata;
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

    public List<Asiento> GetAsientoEstado(bool estado)
    {

        return _context.Asientos.Where(p => p.Estado == estado).ToList();
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

    public void AgregarAsientoAObra(List<AsientoOcupadoDTO> ocupadoDTO)
    {
        foreach (var dto in ocupadoDTO)
        {
            var asientoOriginal = _context.Asientos.FirstOrDefault(a => a.AsientoId == dto.AsientoId);

            if (asientoOriginal == null)
            {
                throw new InvalidOperationException($"No se encontró el Asiento con el ID {dto.AsientoId}");
            }

            var obra = _context.Obras.FirstOrDefault(o => o.ObraId == dto.ObraId);

            if (obra == null)
            {
                throw new InvalidOperationException($"No se encontró la Obra con el ID {dto.ObraId}");
            }

            var asientoNuevo = new Asiento
            {
                NombreAsiento = asientoOriginal.NombreAsiento,
                Estado = true
            };

            obra.AsientosOcupados.Add(asientoNuevo);
        }

        _context.SaveChanges();
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