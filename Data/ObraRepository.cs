namespace Teatro.Data;

using Microsoft.EntityFrameworkCore;
using Teatro.Models;
using System.Globalization;
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
        .Include(p => p.AsientosOcupados)
        .ToList();
    }

    public List<ObraGetDTO> GetAllGeneros(string generoObra)
    {
        var obras = _context.Obras.Where(p => p.Genero == generoObra).Include(p => p.AsientosOcupados).ToList();

        if (obras.Count == 0)
        {
            throw new InvalidOperationException($"No se encontró ninguna obra con el género {generoObra}");
        }

        var obraDTO = obras.Select(obra => new ObraGetDTO
        {
            ObraId = obra.ObraId,
            Imagen = obra.Imagen,
            Genero = obra.Genero,
            Título = obra.Título,
            Descripción = obra.Descripción,
            FechaHora = obra.FechaHora,
            PrecioEntrada = obra.PrecioEntrada,
            AsientosOcupados = obra.AsientosOcupados
        }).ToList();

        return obraDTO;
    }

    public List<ObraGetDTO> BuscarPorTitulo(string titulo)
    {
        var obras = _context.Obras
            .Where(p => p.Título.ToLower().Contains(titulo.ToLower()))
            .Include(p => p.AsientosOcupados)
            .ToList();

        var obraDTO = obras.Select(obra => new ObraGetDTO
        {
            ObraId = obra.ObraId,
            Imagen = obra.Imagen,
            Genero = obra.Genero,
            Título = obra.Título,
            Descripción = obra.Descripción,
        }).ToList();

        return obraDTO;
    }

    public ObraGetAsientosDTO GetAsientosObra(int obraId)
    {
        var obra = IdObra(obraId);

        if (obra == null)
        {
            throw new KeyNotFoundException($"No se encontró la obra con el ID {obraId}.");
        }

        var nuevaObra = new ObraGetAsientosDTO
        {
            ObraId = obra.ObraId,
            AsientosOcupados = obra.AsientosOcupados
        };

        return nuevaObra;
    }


    public ObraGetDTO GetIdObra(int IdObra)
    {
        var obra = _context.Obras.Include(p => p.AsientosOcupados).FirstOrDefault(p => p.ObraId == IdObra);

        if (obra is null)
        {
            throw new InvalidOperationException($"No se encontro la Obra con el id {IdObra}");
        }

        var obraDTO = new ObraGetDTO
        {
            ObraId = obra.ObraId,
            Imagen = obra.Imagen,
            Genero = obra.Genero,
            Título = obra.Título,
            Descripción = obra.Descripción,
            FechaHora = obra.FechaHora,
            PrecioEntrada = obra.PrecioEntrada
        };

        return obraDTO;
    }



    public void CreateObra(ObraAddDTO obra)
    {
        if (obra.FechaHora == default)
        {
            throw new InvalidOperationException("La fecha y hora son inválidas");
        }

        var obraNueva = new Obra
        {
            Imagen = obra.Imagen,
            Genero = obra.Genero,
            Título = obra.Título,
            Descripción = obra.Descripción,
            FechaHora = obra.FechaHora,
            PrecioEntrada = obra.PrecioEntrada
        };

        _context.Obras.Add(obraNueva);
        SaveChanges();
    }

    public void UpdateObra(Obra obra)
    {
        var update = IdObra(obra.ObraId);

        if (update is null)
        {
            throw new KeyNotFoundException("No se encontro la obra a actualizar.");
        }

        _context.Entry(update).CurrentValues.SetValues(obra);
        SaveChanges();
    }

    public void UpdateObraImg(ObraPutImgDTO imagen)
    {
        var obra = IdObra(imagen.ObraId);

        if (obra == null)
        {
            throw new KeyNotFoundException($"No se encontró la obra con el ID {imagen.ObraId}.");
        }

        obra.Imagen = imagen.Imagen;
        SaveChanges();
    }

    public void UpdateObraInfo(ObraPutInfoDTO obraInfo)
    {
        var obra = IdObra(obraInfo.ObraId);

        if (obra == null)
        {
            throw new KeyNotFoundException($"No se encontró la obra con el ID {obraInfo.ObraId}.");
        }

        if (obraInfo.FechaHora == default)
        {
            throw new InvalidOperationException("La fecha y hora son inválidas");
        }

        obra.Genero = obraInfo.Genero;
        obra.Título = obraInfo.Título;
        obra.Descripción = obraInfo.Descripción;
        obra.FechaHora = obraInfo.FechaHora;
        obra.PrecioEntrada = obraInfo.PrecioEntrada;

        SaveChanges();
    }



    public void DeleteObra(int idObra)
    {
        var obra = IdObra(idObra);

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

    private Obra IdObra(int IdObra)
    {
        var obra = _context.Obras.Include(p => p.AsientosOcupados).FirstOrDefault(p => p.ObraId == IdObra);

        if (obra is null)
        {
            throw new InvalidOperationException($"No se encontro la Obra con el id {IdObra}");
        }

        return obra;
    }
}