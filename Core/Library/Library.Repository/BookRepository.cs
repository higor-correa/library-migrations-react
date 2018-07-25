using Library.Domain.Entities;
using Library.Repository.Context;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.Repository
{
    public class BookRepository : BaseCrudRepository<BookEntity>, IBookRepository
    {
        public BookRepository(LibraryContext dbContext) : base(dbContext)
        { }

        protected override IQueryable<BookEntity> Include(IQueryable<BookEntity> query)
        {
            return query.Include(x => x.AuthorsBook)
                        .Include(x => x.BookCategories)
                        .Include(x => x.Publishier);
        }
    }
}
