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
    public async Task<Voluntario> PegarPorNome(string nome)
    {
        if (!string.IsNullOrWhiteSpace(nome))
        {
            return _context.Voluntarios.FirstOrDefault(x => x.Nome.Contains(nome));
        }   
        return null;
    }

    public override Voluntario PegarPorId(int id)
    {
        return _dbSet
        .Include(x => x.Endereco)
        .FirstOrDefault(x => x.Id == id);
    }

}