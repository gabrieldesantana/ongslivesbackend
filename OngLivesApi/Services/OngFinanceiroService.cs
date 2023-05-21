using ONGLIVES.API.Entidades;
using ONGLIVESAPI.Interfaces;

public class OngFinanceiroService : IOngFinanceiroService
{
    private readonly IOngFinanceiroRepository _repository;
    public OngFinanceiroService(IOngFinanceiroRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<OngFinanceiro> Editar(EditOngFinanceiroModel ongFinanceiro)
    {
        var ongFinanceiroEdit = _repository.PegarPorId(ongFinanceiro.Id);

        if (ongFinanceiroEdit == null)
            return null;
        
        ongFinanceiroEdit.Id = ongFinanceiro.Id;
        ongFinanceiroEdit.IdOng = ongFinanceiro.IdOng;
        ongFinanceiroEdit.Tipo = ongFinanceiro.Tipo;
        ongFinanceiroEdit.Valor = ongFinanceiro.Valor;
        ongFinanceiroEdit.Origem = ongFinanceiro.Origem;

        ongFinanceiroEdit = await _repository.Editar(ongFinanceiroEdit);

        return ongFinanceiroEdit;
    }

    public async Task<List<OngFinanceiro>> PegarTodos()
    {
        return await _repository.PegarTodos();
    }

    public async Task<OngFinanceiro> PegarPorId(int id)
    {
        var ongFinanceiro = _repository.PegarPorId(id);

        if (ongFinanceiro == null)
            return null;

        return _repository.PegarPorId(id);
    }

    public async Task<bool> Deletar(int id)
    {
        var ongFinanceiro = _repository.PegarPorId(id);

        if (ongFinanceiro == null)
            return false;
            
        await _repository.Deletar(id);
        return true;
    }
}