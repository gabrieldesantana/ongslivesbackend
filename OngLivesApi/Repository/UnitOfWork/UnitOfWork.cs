using ONGLIVES.API.Persistence.Context;

public class UnitOfWork : IUnitOfWork
{
    private readonly OngLivesContext _context;

    public UnitOfWork(OngLivesContext context)
    {
        _context = context;
    }
    public void Commit()
    {
        _context.SaveChanges();
    }
    public void Rollback()
    {
        
    }
}