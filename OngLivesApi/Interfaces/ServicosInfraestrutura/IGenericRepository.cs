using ONGLIVES.API.Entidades;

namespace ONGLIVES.API.Interfaces.ServicosInfraestrutura
{
    public interface IGenericRepository<T> where T: class
    {
        public Task<List<T>> PegarTodosAsync();
        public Task<T> CadastrarAsync(T entity);
        public Task AdicionarPropriedadeAsync(T entity);
        public Task<T> PegarPorIdAsync(int id);
        public Task<T> EditarAsync(T entity);
        public Task DeletarAsync(int id);
    }
}
