namespace Teatro.Business;

using Teatro.Data;
public class ObraServices : IObraServices
{

    private readonly IObraRepository _obraRepository;

    public ObraServices(IObraRepository repository)
    {
        _obraRepository = repository;
    }

}
