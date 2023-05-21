using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Entidades;
using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;

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