using NewBook.Domain.Entities;

namespace NewBook.Application.Interface.Application
{
    public interface IApplicationBase<T> where T : class
    {
        T GetById(int id);

        Task<T> GetByIdAsync(int id);

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