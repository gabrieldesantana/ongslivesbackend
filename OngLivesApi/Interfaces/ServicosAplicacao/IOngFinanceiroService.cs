using ONGLIVES.API.Entidades;

namespace ONGLIVES.API.Interfaces;

public interface IOngFinanceiroService 
{
    public Task<List<OngFinanceiro>> PegarTodosAsync();
    public Task<OngFinanceiro> PegarPorIdAsync(int id);
    public Task<OngFinanceiro> EditarAsync(int id, EditOngFinanceiroModel ongFinanceiro);
    public Task<bool> DeletarAsync(int id);

}