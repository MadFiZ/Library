using Library.DAL.Context;
using Library.DAL.Interfaces;
using Library.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly LibraryContext _context;
        private DbSet<T> _entities;

        public Repository(LibraryContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _entities.AsEnumerable();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public T Get(int id)
        {
            try
            {
                return _entities.SingleOrDefault(s => s.Id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _entities.Add(entity);
                SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _context.Entry(entity).State = EntityState.Modified;
                SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Remove(T entity)
        {
            try
            {
                _entities.Remove(entity);
                SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
