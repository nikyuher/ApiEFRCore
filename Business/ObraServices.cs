namespace Teatro.Business;

using Teatro.Data;
using Teatro.Models;
public class ObraServices : IObraServices
{

    private readonly IObraRepository _obraRepository;

    public ObraServices(IObraRepository repository)
    {
        _obraRepository = repository;
    }

    public List<Obra> GetAllObras()
    {
        return _obraRepository.GetAllObras();
    }

    public List<ObraGetDTO> GetAllGeneros(string generoObra)
    {
        return _obraRepository.GetAllGeneros(generoObra);
    }

    public ObraGetAsientosDTO GetAsientosObra(int obraId)
    {
       return _obraRepository.GetAsientosObra(obraId);
    }

    public ObraGetDTO GetIdObra(int idObra)
    {
        return _obraRepository.GetIdObra(idObra);
    }


    public void CreateObra(ObraAddDTO obra)
    {
        _obraRepository.CreateObra(obra);
    }

    public void UpdateObra(Obra obra)
    {
        _obraRepository.UpdateObra(obra);
    }

    public void UpdateObraImg(ObraPutImgDTO imagen)
    {
        _obraRepository.UpdateObraImg(imagen);
    }
    public void UpdateObraInfo(ObraPutInfoDTO obraInfo)
    {
        _obraRepository.UpdateObraInfo(obraInfo);
    }

    public void DeleteObra(int obra)
    {
        _obraRepository.DeleteObra(obra);
    }

}
