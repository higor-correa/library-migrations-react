using System;
using System.Linq;
using Library.Domain.Entities;
using Library.Repository.Context;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public class AuthorRepository : BaseCrudRepository<AuthorEntity>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext dbContext) : base(dbContext)
        { }

        public IQueryable<AuthorEntity> AuthorsOfBook(Guid bookId)
        {
            return GetAll()
                .Where(x => x.BooksAuthor.Any(b => b.BookId == bookId));
        }
    }
}
