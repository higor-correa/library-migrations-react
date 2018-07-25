using Library.Domain.Entities;
using Library.Repository.Context;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public class BookCategoryRepository : BaseCrudRepository<BookCategoryEntity>, IBookCategoryRepository
    {
        public BookCategoryRepository(LibraryContext dbContext) : base(dbContext)
        { }
    }
}
