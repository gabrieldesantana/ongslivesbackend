using ONGLIVES.API.Entidades;

namespace ONGLIVES.API.Interfaces;

public interface IUsuarioService 
{
    public Task<List<Usuario>> PegarTodosAsync();
    public Task<Usuario> PegarPorIdAsync(int id);
    public Task<Usuario> PegarPorEmailAsync(string email);
    public Task<Usuario> CadastrarAsync(InputUsuarioModel inputUsuarioModel);
    public Task<Usuario> EditarAsync(int id, EditUsuarioModel editUsuarioModel);
    public Task<bool> DeletarAsync(int id);
    public Task<bool> UpdateSituationAsync(int id);
}