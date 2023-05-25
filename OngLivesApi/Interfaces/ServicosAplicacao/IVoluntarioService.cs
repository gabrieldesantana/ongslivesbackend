using ONGLIVES.API.Entidades;

namespace ONGLIVESAPI.Interfaces;

public interface IVoluntarioService 
{
    public Task<List<Voluntario>> PegarTodosAsync();
    public Task<Voluntario> PegarPorIdAsync(int id);
    public Task<Voluntario> CadastrarAsync(InputVoluntarioModel inputVoluntarioModel);
    public Task<Voluntario> EditarAsync(EditVoluntarioModel voluntario);
    public Task<bool> DeletarAsync(int id);

}