using NewBook.Application.Interface.Application;
using NewBook.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBook.Application.Application
{
    public class ApplicationBase<T> : IDisposable, IApplicationBase<T> where T : class
    {
        private readonly IServiceBase<T> _serviceBase;

        public ApplicationBase(IServiceBase<T> iserviceBase)
        {
            _serviceBase = iserviceBase;
        }

        public string Add(T entity)
        {
            return _serviceBase.Add(entity);
        }
        public bool UpdateRange(List<T> entity)
        {
            return _serviceBase.UpdateRange(entity);
        }
        public bool AddRange(List<T> entity)
        {
            return _serviceBase.AddRange(entity);
        }
        public void Delete(T entity)
        {
            _serviceBase.Delete(entity);
        }

        public bool DeleteRange(List<T> entity)
        {
            return _serviceBase.DeleteRange(entity);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public T GetById(Guid id)
        {
            return _serviceBase.GetById(id);
        }
        public void Update(T entity)
        {
            _serviceBase.Update(entity);
        }
        public async Task<string> AddAsync(T entity)
        {
            return await _serviceBase.AddAsync(entity);
        }
        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            return await _serviceBase.AddRangeAsync(entity);
        }
    }
}
