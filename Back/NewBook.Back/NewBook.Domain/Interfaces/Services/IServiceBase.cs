using NewBook.Domain.Entities;

namespace NewBook.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();

        void Delete(T entity);

        void Update(T entity);

        Task UpdateAsync(T entity);

        int Add(T entity);

        bool AddRange(List<T> entity);

        bool UpdateRange(List<T> entity);

        bool DeleteRange(List<T> entity);

        void Dispose();

        Task<int> AddAsync(T entity);

        Task<bool> AddRangeAsync(List<T> entity);
        Task<ChaveValor> ObterChaveValor(string chave);
    }
}