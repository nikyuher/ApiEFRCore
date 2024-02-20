namespace Teatro.Business;

using Teatro.Models;

public interface IObraServices
{
    List<Obra> GetAllObras();
    public Obra GetIdObra(int IdObra);
    void CreateObra(Obra obra);
    void UpdateObra(Obra obra);
    void DeleteObra(int idObra);

}
