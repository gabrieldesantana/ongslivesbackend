using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Entidades;
using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;

public class OngRepository : GenericRepository<Ong>, IOngRepository
{
    public OngRepository(OngLivesContext context, IUnitOfWork unitOfWork) 
    : base(context, unitOfWork)
    {
    }

    public async Task<Ong> PegarPorNome(string nome)
    {
        if (!string.IsNullOrWhiteSpace(nome))
        {
            return _context.Ongs.FirstOrDefault(x => x.Nome.Contains(nome));
        }
        return null;
    }

    public void AdicionarVaga(Ong ong)
    {
        try
        {
            _context.Entry(ong).State = EntityState.Modified;
            _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            _unitOfWork.Rollback();
        }
    }

    public void AdicionarFinanceiro(Ong ong)
    {
        try
        {
            _context.Entry(ong).State = EntityState.Modified;
            _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            _unitOfWork.Rollback();
        }
    }

    public override Ong PegarPorId(int id)
    {
        return _dbSet
        .Include(x => x.Vagas)
        .Include(x => x.Financeiros)
        .Include(x => x.Endereco)
        .FirstOrDefault(x => x.Id == id);
    }
}