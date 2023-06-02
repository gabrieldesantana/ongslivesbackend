using ONGLIVES.API.Entidades;

namespace ONGLIVES.API.Interfaces;

public interface IOngService
{
    public Task<Ong> PegarPorIdAsync(int id);
    public Task<Ong> PegarPorEmailAsync(string email);
    public Task<List<Ong>> PegarTodosAsync();
    public Task<Ong> CadastrarAsync(InputOngModel ong);
    public Task AdicionarVagaAsync(Ong ong);
    public Task AdicionarFinanceiroAsync(Ong ong);
    public Task AdicionarFotoAsync(Ong ong);
    public Task<Ong> EditarAsync(int id, EditOngModel ong);
    public Task<bool> DeletarAsync(int id);
}