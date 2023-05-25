using ONGLIVES.API.Entidades;

namespace ONGLIVESAPI.Interfaces;
public interface IVagaService 
{
    public Task<List<Vaga>> PegarTodosAsync();
    public Task<Vaga> PegarPorIdAsync(int id);
    public Task<Vaga> CadastrarAsync(InputVagaModel inputVagaModel);
    public Task<Vaga> EditarAsync(EditVagaModel vaga);
    public Task<bool> DeletarAsync(int id);
}