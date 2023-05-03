﻿namespace IA.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        int Add(T entity);
        bool AddRange(List<T> entity);
        bool UpdateRange(List<T> entity);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        bool DeleteRange(List<T> entity);
        void Dispose();
        Task<int> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entity);
    }
}