using ONGLIVES.API.Entidades;

namespace ONGLIVES.API.Interfaces;
public interface IExperienciaService 
{
    public Task<List<Experiencia>> PegarTodosAsync();
    public Task<Experiencia> CadastrarAsync(InputExperienciaModel inputExperienciaModel);
    public Task<Experiencia> EditarAsync(int id, EditExperienciaModel experiencia);
    public Task<bool> DeletarAsync(int id);
    public Task<Experiencia> PegarPorIdAsync(int id);

}