using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Repository.Interfaces
{
    public interface ICrudRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Get(Guid id, bool includeChildren);
        TEntity Get(Guid id);
        TEntity GetAsNoTracking(Guid id);
        IList<TEntity> GetAll(bool includeChildren);
        IList<TEntity> GetAll();
        IList<TEntity> GetAllAsNoTracking();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IList<PropertyEntry> GetChanges(TEntity entity);
        IQueryable<TEntity> GetQuery();
    }
}
