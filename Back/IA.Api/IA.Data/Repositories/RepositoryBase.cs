using IA.Data.Context;
using IA.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IA.Data.Repositories
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {

        ContextDb db = new ContextDb(null);

        public string Add(T entity)
        {
            ContextDb db = new ContextDb(null);

            db.Set<T>().Add(entity);
            db.SaveChanges();

            PropertyInfo[] properties = entity.GetType().GetProperties();

            string id = "";

            foreach (PropertyInfo property in properties)
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) as KeyAttribute;

                if (attribute != null)
                {
                    id = Guid.Parse(property.GetValue(entity).ToString()).ToString();
                    break;
                }
            }

            return id;
        }

        public Task<string> AddAsync(T entity)
        {
            db.Set<T>().AddAsync(entity);
            db.SaveChangesAsync();

            PropertyInfo[] properties = entity.GetType().GetProperties();

            string id = "";

            foreach (PropertyInfo property in properties)
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) as KeyAttribute;

                if (attribute != null)
                {
                    id = Guid.Parse(property.GetValue(entity).ToString()).ToString();
                    break;
                }
            }

            return Task.FromResult(id);
        }

        public bool AddRange(List<T> entity)
        {
            try
            {
                db.Set<T>().AddRange(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }

        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            try
            {
                db.Set<T>().AddRangeAsync(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }

        public bool UpdateRange(List<T> entity)
        {
            try
            {
                foreach (var item in entity)
                {
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }


        public bool DeleteRange(List<T> entity)
        {
            if (entity != null)
            {
                db.Set<T>().RemoveRange(entity);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public T GetById(Guid id)
        {
            var find = db.Set<T>().Find(id);

            db.Entry(find).State = EntityState.Detached;

            return find;
        }

        public void Update(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                ContextDb db2 = new ContextDb(null);
                db2.Entry(entity).State = EntityState.Modified;
                db2.SaveChanges();
            }
        }

        public void Dispose()
        {

            //throw new NotImplementedException();
        }
    }
}