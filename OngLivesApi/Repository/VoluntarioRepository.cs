using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Entidades;
using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;
public class VoluntarioRepository : GenericRepository<Voluntario>,  IVoluntarioRepository
{
    public VoluntarioRepository(OngLivesContext context, IUnitOfWork unitOfWork)
        : base (context, unitOfWork)
    {
    }
    public async Task<Voluntario> PegarPorNomeAsync(string nome)
    {
        if (!string.IsNullOrWhiteSpace(nome))
        {
            return await _context.Voluntarios.FirstOrDefaultAsync(x => x.Nome.ToUpper().Contains(nome.ToUpper()));
        }   
        return null;
    }

    public async Task<Voluntario> PegarPorEmailAsync(string email)
    {
        return await _context.Voluntarios
        .FirstOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper());
    }

    public override async Task<Voluntario> PegarPorIdAsync(int id)
    {
        var voluntario = await _dbSet
        .Include(x => x.Endereco)
        .FirstOrDefaultAsync(x => x.Id == id);
        return voluntario;
    }

    // public void AdicionarPropriedade(Voluntario voluntario)
    // {
    //     try
    //     {
    //         _context.Entry(voluntario).State = EntityState.Modified;
    //         _unitOfWork.Commit();
    //     }
    //     catch (Exception ex)
    //     {
    //         _unitOfWork.Rollback();
    //     }
    // }

}