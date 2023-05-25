using ONGLIVES.API.Entidades;
using ONGLIVESAPI.Interfaces;

public class VoluntarioService : IVoluntarioService
{
    private readonly IVoluntarioRepository _repository;
    public VoluntarioService(IVoluntarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Voluntario>> PegarTodosAsync()
    {
        return await _repository.PegarTodosAsync();
    }

    public async Task<Voluntario> PegarPorIdAsync(int id)
    {
        var voluntario = _repository.PegarPorId(id);

        if (voluntario == null)
            return null;

        return _repository.PegarPorId(id);
    }

    public async Task<Voluntario> CadastrarAsync(InputVoluntarioModel inputVoluntarioModel)
    {
        if (inputVoluntarioModel == null)
            throw new Exception("Voluntario sem informacoes");

        var voluntario = new Voluntario 
        (
        inputVoluntarioModel.Nome,
        inputVoluntarioModel.CPF,
        inputVoluntarioModel.DataNascimento,
        inputVoluntarioModel.Escolaridade,
        inputVoluntarioModel.Genero,
        inputVoluntarioModel.Email,
        inputVoluntarioModel.Telefone,
        inputVoluntarioModel.Habilidade,
        inputVoluntarioModel.Avaliacao,
        inputVoluntarioModel.HorasVoluntaria,
        inputVoluntarioModel.QuantidadeExperiencias,
        inputVoluntarioModel.Endereco
        );

        await _repository.CadastrarAsync(voluntario);
        
        return voluntario;
    }

    public async Task<Voluntario> EditarAsync(EditVoluntarioModel editVoluntarioModel)
    {
        var voluntarioEdit = _repository.PegarPorId(editVoluntarioModel.Id);

        if (voluntarioEdit == null)
            return null;

        voluntarioEdit.Id = editVoluntarioModel.Id;
        voluntarioEdit.Escolaridade = editVoluntarioModel.Escolaridade;
        voluntarioEdit.Email = editVoluntarioModel.Email;
        voluntarioEdit.Telefone = editVoluntarioModel.Telefone;
        voluntarioEdit.Habilidade = editVoluntarioModel.Habilidade;
        voluntarioEdit.Avaliacao = editVoluntarioModel.Avaliacao;
        voluntarioEdit.HorasVoluntaria = editVoluntarioModel.HorasVoluntaria;
        voluntarioEdit.QuantidadeExperiencias = editVoluntarioModel.QuantidadeExperiencias;
        voluntarioEdit.Endereco = editVoluntarioModel.Endereco;


        voluntarioEdit = await _repository.EditarAsync(voluntarioEdit);

        return voluntarioEdit;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var voluntario = _repository.PegarPorId(id);

        if (voluntario == null)
            return false;
            
        await _repository.DeletarAsync(id);
        return true;
    }
}