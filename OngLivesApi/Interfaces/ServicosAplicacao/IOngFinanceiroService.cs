using ONGLIVES.API.Entidades;

namespace ONGLIVESAPI.Interfaces;

public interface IOngFinanceiroService 
{
    public Task<List<OngFinanceiro>> PegarTodosAsync();
    public Task<OngFinanceiro> PegarPorIdAsync(int id);
    public Task<OngFinanceiro> EditarAsync(EditOngFinanceiroModel ongFinanceiro);
    public Task<bool> DeletarAsync(int id);

}