using ONGLIVES.API.Entidades;
using ONGLIVESAPI.Interfaces;

public class OngService : IOngService
{
    private readonly IOngRepository _repository;
    public OngService(IOngRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Ong>> PegarTodos()
    {
        return await _repository.PegarTodos();
    }

    public Ong PegarPorId(int id)
    {
        var ong = _repository.PegarPorId(id);

        if (ong == null)
            return null;

        return _repository.PegarPorId(id);
    }

    public async Task<Ong> Cadastrar(InputOngModel inputOngModel)
    {
        if (inputOngModel == null)
            throw new Exception("Ong sem informações");

        var ong = new Ong 
        (
        inputOngModel.Nome,
        inputOngModel.CNPJ,
        inputOngModel.Telefone,
        inputOngModel.Email,
        inputOngModel.AreaAtuacao,
        inputOngModel.QuantidadeEmpregados,
        inputOngModel.Endereco
        );

        await _repository.Cadastrar(ong);
        return ong;
    }
    
    public async Task AdicionarVaga(Ong ong)
    {
        if (ong == null)
            throw new Exception("Vaga sem informações");
        
        _repository.AdicionarVaga(ong);
    }

    public async Task AdicionarFinanceiro(Ong ong)
    {
        if (ong == null)
            throw new Exception("Financeiro sem informações");
        
        _repository.AdicionarFinanceiro(ong);
    }

    public async Task<Ong> Editar(EditOngModel editOngModel)
    {
        var ongEdit = _repository.PegarPorId(editOngModel.Id);

        if (ongEdit == null)
            return null;

        ongEdit.Id = editOngModel.Id;
        ongEdit.Telefone = editOngModel.Telefone;
        ongEdit.Email = editOngModel.Email;
        ongEdit.QuantidadeEmpregados = editOngModel.QuantidadeEmpregados;
        ongEdit.Endereco = editOngModel.Endereco;

        ongEdit = await _repository.Editar(ongEdit);

        return ongEdit;
    }

    public async Task<bool> Deletar(int id)
    {
        var voluntario = _repository.PegarPorId(id);

        if (voluntario == null)
            return false;
            
        await _repository.Deletar(id);
        return true;
    }
}