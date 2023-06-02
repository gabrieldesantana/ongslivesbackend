using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces;

public class OngFinanceiroService : IOngFinanceiroService
{
    private readonly IOngFinanceiroRepository _repository;
    public OngFinanceiroService(IOngFinanceiroRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<OngFinanceiro> EditarAsync(int id, EditOngFinanceiroModel ongFinanceiro)
    {
        var ongFinanceiroEdit = await _repository.PegarPorIdAsync(id);

        if (ongFinanceiroEdit == null) return null;
        
        ongFinanceiroEdit.Id = id;
        ongFinanceiroEdit.IdOng = ongFinanceiro.IdOng;
        ongFinanceiroEdit.Tipo = ongFinanceiro.Tipo;
        ongFinanceiroEdit.Valor = ongFinanceiro.Valor;
        ongFinanceiroEdit.Origem = ongFinanceiro.Origem;

        ongFinanceiroEdit = await _repository.EditarAsync(ongFinanceiroEdit);

        return ongFinanceiroEdit;
    }

    public async Task<List<OngFinanceiro>> PegarTodosAsync()
    {
        return await _repository.PegarTodosAsync();
    }

    public async Task<OngFinanceiro> PegarPorIdAsync(int id)
    {
        var ongFinanceiro = await _repository.PegarPorIdAsync(id);

        if (ongFinanceiro == null) return null;

        return ongFinanceiro;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var ongFinanceiro = await _repository.PegarPorIdAsync(id);

        if (ongFinanceiro == null) return false;
            
        await _repository.DeletarAsync(id);
        return true;
    }
}