using Library.Domain.Entities;
using Library.Repository.Context;

namespace Library.Repository
{
    public class BookCategoryRepository : BaseRepository<BookCategoryEntity>
    {
        public BookCategoryRepository(LibraryContext dbContext) : base(dbContext)
        { }
    }
}
