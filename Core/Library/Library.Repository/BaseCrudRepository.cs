using Library.Domain.Entities;
using Library.Repository.Context;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Repository
{
    public abstract class BaseCrudRepository<TEntity> : ICrudRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly LibraryContext _dbContext;
        private IQueryable<TEntity> _where;

        public BaseCrudRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public IList<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity Get(Guid id)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(e => e.Id == id);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IList<PropertyEntry> GetChanges(TEntity entity)
        {
            return _dbContext.Entry(entity).Properties
                .Where(e => e.IsModified)
                .ToList();
        }
    }
}