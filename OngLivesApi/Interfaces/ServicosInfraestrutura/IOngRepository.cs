using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces.ServicosInfraestrutura;

public interface IOngRepository : IGenericRepository<Ong>
{
    public Task<Ong> PegarPorNomeAsync(string nome);
    public Task<Ong> PegarPorEmailAsync(string email);
    // public void AdicionarVaga(Ong ong);
    // public void AdicionarFinanceiro(Ong ong);
    // public void AdicionarFoto(Ong ong);
    // public void AdicionarPropriedade(Ong ong);
}