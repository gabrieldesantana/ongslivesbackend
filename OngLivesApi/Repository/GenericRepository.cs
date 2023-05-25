using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces.ServicosInfraestrutura;
using ONGLIVES.API.Persistence.Context;

namespace ONGLIVES.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Base
    {
        protected readonly OngLivesContext _context;
        protected readonly DbSet<T> _dbSet;
        protected readonly IUnitOfWork _unitOfWork;
        public GenericRepository(OngLivesContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _unitOfWork = unitOfWork;
        }

        public async Task<List<T>> PegarTodosAsync()
        {
            return _dbSet
            .ToList()
            .FindAll(x => x.Actived == true);
        }

        public virtual T PegarPorId(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> CadastrarAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
            return entity;
        }

        public async Task<T> EditarAsync(T entity)
        {
            var result = PegarPorId(entity.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    _unitOfWork.Commit();
                }
                catch (Exception)
                {
                    _unitOfWork.Rollback();
                }
            }
            return entity;
        }

        public async Task DeletarAsync(int id)
        {
            var retorno = PegarPorId(id);

            if (retorno != null) 
            {
                try
                {
                    retorno.Actived = false;
                    _unitOfWork.Commit();
                }
                catch (Exception)
                {

                    _unitOfWork.Rollback();
                }
            }
        }

        public bool Exists(int id)
        {
            return _dbSet.Any(x => x.Id.Equals(id));
        }
    }
}