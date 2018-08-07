using Library.Domain.Entities;
using Library.Repository.Context;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Library.Repository
{
    public class BookRepository : BaseCrudRepository<BookEntity>, IBookRepository
    {
        public BookRepository(LibraryContext dbContext) : base(dbContext)
        { }

        protected override IQueryable<BookEntity> Include(IQueryable<BookEntity> query)
        {
            return query.Include(x => x.AuthorsBook)
                        .ThenInclude(authorBook => authorBook.Author)
                        .Include(x => x.BookCategories)
                        .Include(x => x.Publishier);
        }

        private Expression<Func<AuthorBookEntity, object>> ASSFD()
        {
            return x => x.Author;
        }
    }
}
