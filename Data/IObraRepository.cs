namespace Teatro.Data;
using Teatro.Models;

public interface IObraRepository
{
    public List<Obra> GetAllObras();
    public Obra GetIdObra(int IdObra);
    void CreateObra(Obra obra);
    void UpdateObra(Obra obra);
    void DeleteObra(int idObra);
    void SaveChanges();
}