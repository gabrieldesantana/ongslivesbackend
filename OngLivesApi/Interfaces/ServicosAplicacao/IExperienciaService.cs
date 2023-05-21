using ONGLIVES.API.Entidades;

namespace ONGLIVESAPI.Interfaces;
public interface IExperienciaService 
{
    public Task<List<Experiencia>> PegarTodos();
    public Task<Experiencia> Cadastrar(InputExperienciaModel inputExperienciaModel);
    public Task<Experiencia> Editar(EditExperienciaModel experiencia);
    public Task<bool> Deletar(int id);
    public Task<Experiencia> PegarPorId(int id);

}