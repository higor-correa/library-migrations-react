using Library.Domain.Entities;
using Library.Repository.Context;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public class BookRepository : BaseCrudRepository<BookEntity>, IBookRepository
    {
        public BookRepository(LibraryContext dbContext) : base(dbContext)
        { }
    }
}
