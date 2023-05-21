using ONGLIVES.API.Entidades;

namespace ONGLIVESAPI.Interfaces;

public interface IVoluntarioService 
{
    public Task<List<Voluntario>> PegarTodos();
    public Task<Voluntario> PegarPorId(int id);
    public Task<Voluntario> Cadastrar(InputVoluntarioModel inputVoluntarioModel);
    public Task<Voluntario> Editar(EditVoluntarioModel voluntario);
    public Task<bool> Deletar(int id);

}