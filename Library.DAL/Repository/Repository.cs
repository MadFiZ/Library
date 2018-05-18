using Library.DAL.Context;
using Library.DAL.Interfaces;
using Library.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected LibraryContext _context;
        protected DbSet<T> _entities;

        public Repository(LibraryContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            try
            {
                return _entities;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            try
            {
                return await _entities.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual T Get(int id)
        {
            try
            {
                return _entities.Find(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual async Task<T> GetAsync(int id)
        {
            try
            {
                return await _entities.FindAsync(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void Add(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _entities.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            try
            {
                _entities.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public virtual void Update(T entity, object key)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                T exist = _entities.Find(key);
                if (exist != null)
                {
                    _context.Entry(exist).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                }

            }
             catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual async Task<bool> UpdateAsync(T entity, object key)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                T exist = await _entities.FindAsync(key);
                if (exist != null)
                {
                    _context.Entry(exist).CurrentValues.SetValues(entity);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                _entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async virtual Task<bool> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
