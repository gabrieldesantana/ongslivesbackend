using ONGLIVES.API.Entidades;
using ONGLIVESAPI.Interfaces;

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

    public async Task<Experiencia> EditarAsync(EditExperienciaModel editExperienciaModel)
    {
        var experienciaEdit = _repository.PegarPorId(editExperienciaModel.Id);
        
        if (experienciaEdit == null)
            return null;

        experienciaEdit.Id = editExperienciaModel.Id;
        experienciaEdit.ProjetoEnvolvido = editExperienciaModel.ProjetoEnvolvido;
        experienciaEdit.Opiniao = editExperienciaModel.Opiniao;

        experienciaEdit = await _repository.EditarAsync(experienciaEdit);

        return experienciaEdit;
    }

    public async Task<Experiencia> PegarPorIdAsync(int id)
    {
        return _repository.PegarPorId(id);
    }

    public async Task<List<Experiencia>> PegarTodosAsync()
    {
        return await _repository.PegarTodosAsync();
    }
}