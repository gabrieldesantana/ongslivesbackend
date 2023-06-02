using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces.ServicosInfraestrutura;

public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    public Task<Usuario> PegarPorEmailAsync(string email);
}