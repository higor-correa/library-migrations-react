using Library.Domain.Entities;
using Library.Repository.Context;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.Repository
{
    public class AuthorRepository : BaseCrudRepository<AuthorEntity>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext dbContext) : base(dbContext)
        { }

        protected override IQueryable<AuthorEntity> Include(IQueryable<AuthorEntity> query)
        {
            return query.Include(x => x.BooksAuthor)
                        .ThenInclude(x => x.Book)
                        .ThenInclude(x => x.BookCategories);
        }
    }
}
