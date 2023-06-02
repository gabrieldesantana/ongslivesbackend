using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces;

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
        var voluntario = await _repository.PegarPorIdAsync(id);

        if (voluntario == null) return null;

        return voluntario;
    }

    public async Task<Voluntario> PegarPorEmailAsync(string email)
    {
        var voluntario = await _repository.PegarPorEmailAsync(email);

        if (voluntario == null) return null;

        return voluntario;
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
        inputVoluntarioModel.Endereco
        );

        await _repository.CadastrarAsync(voluntario);
        
        return voluntario;
    }

    public async Task AdicionarFotoAsync(Voluntario voluntario)
    {
         if (voluntario == null)
            throw new Exception("Foto sem informações");
        
        // _repository.AdicionarVaga(ong);
        _repository.AdicionarPropriedadeAsync(voluntario);
    }

    public async Task<Voluntario> EditarAsync(int id, EditVoluntarioModel editVoluntarioModel)
    {
        var voluntarioEdit = await _repository.PegarPorIdAsync(id);

        if (voluntarioEdit == null) return null;

        voluntarioEdit.Id = id;
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
        var voluntario = await _repository.PegarPorIdAsync(id);

        if (voluntario == null) return false;
            
        await _repository.DeletarAsync(id);
        return true;
    }
}