using ONGLIVES.API.Entidades;

namespace ONGLIVES.API.Interfaces;

public interface IVoluntarioService 
{
    public Task<List<Voluntario>> PegarTodosAsync();
    public Task<Voluntario> PegarPorIdAsync(int id);
    public Task<Voluntario> PegarPorEmailAsync(string email);
    public Task<Voluntario> CadastrarAsync(InputVoluntarioModel inputVoluntarioModel);
    public Task AdicionarFotoAsync(Voluntario voluntario);
    public Task<Voluntario> EditarAsync(int id, EditVoluntarioModel voluntario);
    public Task<bool> DeletarAsync(int id);

}