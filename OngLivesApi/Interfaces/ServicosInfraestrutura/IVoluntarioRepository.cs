using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces.ServicosInfraestrutura;

public interface IVoluntarioRepository : IGenericRepository<Voluntario>
{
    public Task<Voluntario> PegarPorNomeAsync(string nome);
}