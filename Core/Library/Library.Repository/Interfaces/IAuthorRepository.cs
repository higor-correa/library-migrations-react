using Library.Domain.Entities;
using System;
using System.Linq;

namespace Library.Repository.Interfaces
{
    public interface IAuthorRepository : ICrudRepository<AuthorEntity>
    {
        IQueryable<AuthorEntity> AuthorsOfBook(Guid bookId);
    }
}
