using Library.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Library.Repository.Interfaces
{
    public interface ICrudRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Get(Guid id);
        IList<TEntity> GetAll();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
