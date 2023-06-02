using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces;

public class VagaService : IVagaService
{
    private readonly IVagaRepository _repository;
    public VagaService(IVagaRepository repository)
    {
        _repository = repository;
    }
    public async Task<Vaga> CadastrarAsync(InputVagaModel inputVagaModel)
    {
        if (inputVagaModel == null)
            throw new Exception("Vaga sem informações");

         var vaga = new Vaga 
        (
        inputVagaModel.IdVoluntario,
        inputVagaModel.IdOng,
        inputVagaModel.Tipo,
        inputVagaModel.Turno,
        inputVagaModel.Descricao,
        inputVagaModel.Habilidade,
        inputVagaModel.DataInicio,
        inputVagaModel.DataFim
        );

        await _repository.CadastrarAsync(vaga);

        return vaga;
    }

    public async Task<Vaga> EditarAsync(int id, EditVagaModel editVagaModel)
    {
        var vagaEdit = await _repository.PegarPorIdAsync(id);
        
        if (vagaEdit == null) return null;

        vagaEdit.Id = id;
        vagaEdit.Tipo = editVagaModel.Tipo;
        vagaEdit.Turno = editVagaModel.Turno;
        vagaEdit.Descricao = editVagaModel.Descricao;
        vagaEdit.Habilidade = editVagaModel.Habilidade;
        vagaEdit.DataInicio = editVagaModel.DataInicio;
        vagaEdit.DataFim = editVagaModel.DataFim;
        vagaEdit.Disponivel = editVagaModel.Disponivel;
        
        vagaEdit = await _repository.EditarAsync(vagaEdit);

        return vagaEdit;
    }

    public async Task<List<Vaga>> PegarTodosAsync()
    {
        return await _repository.PegarTodosAsync();
    }

    public async Task<Vaga> PegarPorIdAsync(int id)
    {
        var vaga = await _repository.PegarPorIdAsync(id);

        if (vaga == null) return null;

        return vaga;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var vaga = await _repository.PegarPorIdAsync(id);

        if (vaga == null) return false;
            
        await _repository.DeletarAsync(id);
        return true;
    }
}