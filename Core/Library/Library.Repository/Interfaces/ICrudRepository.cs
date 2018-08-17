using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Repository.Interfaces
{
    public interface ICrudRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Get(Guid id);
        IQueryable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IList<PropertyEntry> GetChanges(TEntity entity);
    }
}
