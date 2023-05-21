using ONGLIVES.API.Entidades;

namespace ONGLIVESAPI.Interfaces;

public interface IOngService
{
    public Task<List<Ong>> PegarTodos();
    public Task<Ong> Cadastrar(InputOngModel ong);
    public Task AdicionarVaga(Ong ong);
    public Task AdicionarFinanceiro(Ong ong);
    public Task<Ong> Editar(EditOngModel ong);
    public Task<bool> Deletar(int id);
    public Ong PegarPorId(int id);
}