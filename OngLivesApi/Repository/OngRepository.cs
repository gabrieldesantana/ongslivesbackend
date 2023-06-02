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

    public async Task<Ong> PegarPorNomeAsync(string nome)
    {
        if (!string.IsNullOrWhiteSpace(nome))
        {
            return await _context.Ongs.FirstOrDefaultAsync(x => x.Nome.ToUpper().Contains(nome.ToUpper()));
        }
        return null;
    }

    public async Task<Ong> PegarPorEmailAsync(string email)
    {
        return await _context.Ongs.Include(x => x.Vagas).Include(x => x.Financeiros)
        .FirstOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper());
    }

    // public void AdicionarPropriedade(Ong ong)
    // {
    //     try
    //     {
    //         _context.Entry(ong).State = EntityState.Modified;
    //         _unitOfWork.Commit();
    //     }
    //     catch (Exception ex)
    //     {
    //         _unitOfWork.Rollback();
    //     }
    // }

    // public void AdicionarFinanceiro(Ong ong)
    // {
    //     try
    //     {
    //         _context.Entry(ong).State = EntityState.Modified;
    //         _unitOfWork.Commit();
    //     }
    //     catch (Exception ex)
    //     {
    //         _unitOfWork.Rollback();
    //     }
    // }

    // public void AdicionarFoto(Ong ong)
    // {
    //     try
    //     {
    //         _context.Entry(ong).State = EntityState.Modified;
    //         _unitOfWork.Commit();
    //     }
    //     catch (Exception ex)
    //     {
    //         _unitOfWork.Rollback();
    //     }
    // }

    public override async Task<Ong> PegarPorIdAsync(int id)
    {
        var ong = await _dbSet
        .Include(x => x.Vagas)
        .Include(x => x.Financeiros)
        .Include(x => x.Endereco)
        // .Include(x => x.Imagem)
        .FirstOrDefaultAsync(x => x.Id == id);
        return ong;
    }

    public override async Task<List<Ong>> PegarTodosAsync()
    {
        return  _dbSet
        .Include(x => x.Endereco)
        .ToList()
        .FindAll(x => x.Actived == true);
    }
}