using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces.ServicosInfraestrutura;

public interface IOngRepository : IGenericRepository<Ong>
{
    public Task<Ong> PegarPorNomeAsync(string nome);
    public void AdicionarVaga(Ong ong);
    public void AdicionarFinanceiro(Ong ong);
}