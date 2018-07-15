using Library.Domain.Entities;
using Library.Repository.Context;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Library.Repository
{
    public abstract class BaseRepository<TEntity> : ICrudRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly LibraryContext _dbContext;

        public BaseRepository(LibraryContext dbContext)
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
            return _dbContext.Set<TEntity>().SingleOrDefault(l => l.Id == id);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}