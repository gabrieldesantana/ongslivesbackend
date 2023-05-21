using ONGLIVES.API.Entidades;

namespace ONGLIVESAPI.Interfaces;

public interface IOngFinanceiroService 
{
    public Task<List<OngFinanceiro>> PegarTodos();
    public Task<OngFinanceiro> PegarPorId(int id);
    public Task<OngFinanceiro> Editar(EditOngFinanceiroModel ongFinanceiro);
    public Task<bool> Deletar(int id);

}