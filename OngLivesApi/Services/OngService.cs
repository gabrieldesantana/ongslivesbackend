using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces;

public class OngService : IOngService
{
    private readonly IOngRepository _repository;
    private readonly IVagaRepository _vagaRepository;
    public OngService(IOngRepository repository, IVagaRepository vagaRepository)
    {
        _repository = repository;
        _vagaRepository = vagaRepository;
    }

    public async Task<List<Ong>> PegarTodosAsync()
    {
        return await _repository.PegarTodosAsync();
    }

    public async Task<Ong> PegarPorIdAsync(int id)
    {
        var ong = await _repository.PegarPorIdAsync(id);

        var vagas = await _vagaRepository.PegarVagasAsync(ong.Id); //
        ong.Vagas = vagas; //

        if (ong == null) return null;

        return ong;
    }

    public async Task<Ong> PegarPorEmailAsync(string email)
    {
        var ong = await _repository.PegarPorEmailAsync(email);

        var vagas = await _vagaRepository.PegarVagasAsync(ong.Id);
        ong.Vagas = vagas;

        if (ong == null) return null;

        return ong;
    }

    public async Task<Ong> CadastrarAsync(InputOngModel inputOngModel)
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

        await _repository.CadastrarAsync(ong);
        return ong;
    }
    
    public async Task AdicionarVagaAsync(Ong ong)
    {
        if (ong == null)
            throw new Exception("Vaga sem informações");
        
        // _repository.AdicionarVaga(ong);
        _repository.AdicionarPropriedadeAsync(ong);
    }

    public async Task AdicionarFinanceiroAsync(Ong ong)
    {
        if (ong == null)
            throw new Exception("Financeiro sem informações");
        
        // _repository.AdicionarFinanceiro(ong);
        _repository.AdicionarPropriedadeAsync(ong);
    }

    public async Task AdicionarFotoAsync(Ong ong)
    {
        if (ong == null)
            throw new Exception("Foto sem informações");
        
        // _repository.AdicionarFinanceiro(ong);
        _repository.AdicionarPropriedadeAsync(ong);
    }



    public async Task<Ong> EditarAsync(int id, EditOngModel editOngModel)
    {
        var ongEdit = await _repository.PegarPorIdAsync(editOngModel.Id);

        if (ongEdit == null) return null;

        ongEdit.Id = editOngModel.Id;
        ongEdit.Telefone = editOngModel.Telefone;
        ongEdit.Email = editOngModel.Email;
        ongEdit.QuantidadeEmpregados = editOngModel.QuantidadeEmpregados;
        ongEdit.Endereco = editOngModel.Endereco;

        ongEdit = await _repository.EditarAsync(ongEdit);

        return ongEdit;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var voluntario = await _repository.PegarPorIdAsync(id);

        if (voluntario == null) return false;
            
        await _repository.DeletarAsync(id);
        return true;
    }
}