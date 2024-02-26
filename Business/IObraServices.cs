namespace Teatro.Business;

using Teatro.Models;

public interface IObraServices
{
    public List<Obra> GetAllObras();
    public List<Obra> GetAllGeneros(string generoObra);
    public Obra GetIdObra(int IdObra);
    void CreateObra(Obra obra);
    void UpdateObra(Obra obra);
    void UpdateObraImg(ObraPutImgDTO imagen);
    void UpdateObraInfo(ObraPutInfoDTO obraInfo);
    void DeleteObra(int idObra);


}
