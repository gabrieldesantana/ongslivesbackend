using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces;

public class ExperienciaService : IExperienciaService
{
    private readonly IExperienciaRepository _repository;
    private readonly IVoluntarioRepository _voluntarioRepository;
    private readonly IOngRepository _ongRepository;
    public ExperienciaService(IExperienciaRepository repository, IVoluntarioRepository voluntarioRepository, IOngRepository ongRepository)
    {
        _repository = repository;
        _voluntarioRepository = voluntarioRepository;
        _ongRepository = ongRepository;
    }

    public async Task<List<Experiencia>> PegarTodosAsync()
    {
        return await _repository.PegarTodosAsync();
    }

    public async Task<Experiencia> PegarPorIdAsync(int id)
    {
        var experiencia = await _repository.PegarPorIdAsync(id);

        if (experiencia == null) return null;

        return experiencia;
    }

    public async Task<Experiencia> CadastrarAsync(InputExperienciaModel inputExperienciaModel)
    {
        if (inputExperienciaModel == null)
            throw new Exception("Experiencia sem informacoes");

        if (string.IsNullOrEmpty(inputExperienciaModel.NomeVoluntario))
        {
            throw new Exception("NomeVoluntario não informado");
        }
        
        if (string.IsNullOrEmpty(inputExperienciaModel.NomeOng))
        {
            throw new Exception("NomeOng não informado");
        }

        var voluntario = await _voluntarioRepository.PegarPorNomeAsync(inputExperienciaModel.NomeVoluntario);
        var ong = await _ongRepository.PegarPorNomeAsync(inputExperienciaModel.NomeOng);

        var experiencia = new Experiencia 
        (
        inputExperienciaModel.NomeVoluntario,
        inputExperienciaModel.NomeOng,
        inputExperienciaModel.ProjetoEnvolvido,
        inputExperienciaModel.Opiniao,
        inputExperienciaModel.Nota,
        inputExperienciaModel.DataExperienciaInicio,
        inputExperienciaModel.DataExperienciaFim
        );

        experiencia.IdOng = ong.Id;
        experiencia.IdVoluntario = voluntario.Id;

        await _repository.CadastrarAsync(experiencia);
        return experiencia;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        await _repository.DeletarAsync(id);
        return true;
    }

    public async Task<Experiencia> EditarAsync(int id, EditExperienciaModel editExperienciaModel)
    {
        var experienciaEdit = await _repository.PegarPorIdAsync(id);
        
        if (experienciaEdit == null)
            return null;

        experienciaEdit.Id = id;
        experienciaEdit.ProjetoEnvolvido = editExperienciaModel.ProjetoEnvolvido;
        experienciaEdit.Opiniao = editExperienciaModel.Opiniao;
        experienciaEdit.Nota = editExperienciaModel.Nota;

        experienciaEdit = await _repository.EditarAsync(experienciaEdit);

        return experienciaEdit;
    }
}