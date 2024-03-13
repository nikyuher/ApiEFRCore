namespace Teatro.Data;
using Teatro.Models;

public interface IObraRepository
{
    public List<Obra> GetAllObras();
    public List<ObraGetDTO> GetAllGeneros(string generoObra);
    public ObraGetAsientosDTO GetAsientosObra(int obraId);
    public ObraGetDTO GetIdObra(int IdObra);
    void CreateObra(ObraAddDTO obra);
    void UpdateObra(Obra obra);
    void UpdateObraImg(ObraPutImgDTO imagen);
    void UpdateObraInfo(ObraPutInfoDTO obraInfo);
    void DeleteObra(int idObra);
    void SaveChanges();
}