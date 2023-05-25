using ONGLIVES.API.Entidades;

namespace ONGLIVESAPI.Interfaces;

public interface IOngService
{
    public Task<List<Ong>> PegarTodosAsync();
    public Task<Ong> CadastrarAsync(InputOngModel ong);
    public Task AdicionarVagaAsync(Ong ong);
    public Task AdicionarFinanceiroAsync(Ong ong);
    public Task<Ong> EditarAsync(EditOngModel ong);
    public Task<bool> DeletarAsync(int id);
    public Ong PegarPorId(int id);
}