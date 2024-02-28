namespace Teatro.Data;

using Microsoft.EntityFrameworkCore;
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
        return _context.Obras
        .Include(p => p.ObrasAsientos)
        .ThenInclude(r => r.Asiento)
        .ToList();
    }

    public List<Obra> GetAllGeneros(string generoObra)
    {
        var obras = _context.Obras.Where(p => p.Genero == generoObra).ToList();

        if (obras.Count == 0)
        {
            throw new InvalidOperationException($"No se encontró ninguna obra con el género {generoObra}");
        }

        return obras;
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

    public void UpdateObraImg(ObraPutImgDTO imagen)
    {
        var obra = GetIdObra(imagen.ObraId);

        if (obra == null)
        {
            throw new KeyNotFoundException($"No se encontró la obra con el ID {imagen.ObraId}.");
        }

        obra.Imagen = imagen.Imagen;
        SaveChanges();
    }

    public void UpdateObraInfo(ObraPutInfoDTO obraInfo)
    {
        var obra = GetIdObra(obraInfo.ObraId);

        if (obra == null)
        {
            throw new KeyNotFoundException($"No se encontró la obra con el ID {obraInfo.ObraId}.");
        }

        obra.Genero = obraInfo.Genero;
        obra.Título = obraInfo.Título;
        obra.Descripción = obraInfo.Descripción;
        obra.PrecioEntrada = obraInfo.PrecioEntrada;

        SaveChanges();
    }

    public void DeleteObra(int idObra)
    {
        var obra = GetIdObra(idObra);

        if (obra is null)
        {
            throw new InvalidOperationException($"No se encontro la Obra con el id {idObra}");
        }

        var DetalleSala = _context.Reservas.Where(ob => ob.ObraId == idObra);

        _context.Reservas.RemoveRange(DetalleSala);
        _context.Obras.Remove(obra);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}