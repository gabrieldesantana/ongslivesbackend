using ONGLIVES.API.Entidades;

namespace ONGLIVES.API.Interfaces.ServicosInfraestrutura
{
    public interface IGenericRepository<T> where T: class
    {
        public Task<List<T>> PegarTodos();
        public Task<T> Cadastrar(T entity);
        public T PegarPorId(int id);
        public Task<T> Editar(T entity);
        public Task Deletar(int id);
    }
}
