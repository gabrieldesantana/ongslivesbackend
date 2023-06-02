using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Entidades;
using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;
public class UsuarioRepository : GenericRepository<Usuario>,  IUsuarioRepository
{
    public UsuarioRepository(OngLivesContext context, IUnitOfWork unitOfWork)
        : base (context, unitOfWork)
    {
    }
    public override async Task<List<Usuario>> PegarTodosAsync()
    {
        return _context.Usuarios
        .ToList();
    }

    public async Task<Usuario> PegarPorEmailAsync(string email)
    {
        return await _context.Usuarios
        .FirstOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper());
    }

}