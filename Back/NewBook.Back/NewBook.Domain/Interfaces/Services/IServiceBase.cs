namespace NewBook.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();

        void Delete(T entity);

        void Update(T entity);

        string Add(T entity);

        bool AddRange(List<T> entity);

        bool UpdateRange(List<T> entity);

        bool DeleteRange(List<T> entity);

        void Dispose();

        Task<string> AddAsync(T entity);

        Task<bool> AddRangeAsync(List<T> entity);
    }
}