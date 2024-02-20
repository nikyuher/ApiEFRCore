namespace Teatro.Data;

public class ObraEFRepository : IObraRepository
{
    private readonly TeatroContext _context;

    public ObraEFRepository(TeatroContext context)
    {
        _context = context;
    }


}