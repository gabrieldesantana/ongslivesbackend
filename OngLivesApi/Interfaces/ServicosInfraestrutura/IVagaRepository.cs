using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces.ServicosInfraestrutura;

public interface IVagaRepository : IGenericRepository<Vaga>
{
    Task<List<Vaga>> PegarVagasAsync(int idOng);
}