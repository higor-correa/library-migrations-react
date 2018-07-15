using Library.Domain.Entities;
using Library.Repository.Context;

namespace Library.Repository
{
    public class BookRepository : BaseRepository<BookEntity>
    {
        public BookRepository(LibraryContext dbContext) : base(dbContext)
        { }

    }
}
