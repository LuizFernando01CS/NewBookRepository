using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Repositories;
using NewBook.Domain.Interfaces.Services;

namespace NewBook.Domain.Services
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _irepositoryBase;

        public ServiceBase(IRepositoryBase<T> irepositoryBase)
        {
            _irepositoryBase = irepositoryBase;
        }

        public int Add(T entity)
        {
            return _irepositoryBase.Add(entity);
        }
        public bool UpdateRange(List<T> entity)
        {
            return _irepositoryBase.UpdateRange(entity);
        }
        public bool AddRange(List<T> entity)
        {
            return _irepositoryBase.AddRange(entity);
        }
        public void Delete(T entity)
        {
            _irepositoryBase.Delete(entity);
        }

        public bool DeleteRange(List<T> entity)
        {
            return _irepositoryBase.DeleteRange(entity);
        }

        public void Dispose()
        {
            _irepositoryBase.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return _irepositoryBase.GetAll();
        }

        public T GetById(int id)
        {
            return _irepositoryBase.GetById(id);
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _irepositoryBase.GetByIdAsync(id);
        }
        public void Update(T entity)
        {
            _irepositoryBase.Update(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _irepositoryBase.UpdateAsync(entity);
        }
        public async Task<int> AddAsync(T entity)
        {
            return await _irepositoryBase.AddAsync(entity);
        }
        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            return await _irepositoryBase.AddRangeAsync(entity);
        }

        public async Task<ChaveValor> ObterChaveValor(string chave)
        {
            return await _irepositoryBase.ObterChaveValor(chave);
        }
    }
}