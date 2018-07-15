using Library.Domain.Entities;
using Library.Repository.Context;

namespace Library.Repository
{
    public class AuthorBookRepository : BaseRepository<AuthorBookEntity>
    {
        public AuthorBookRepository(LibraryContext dbContext) : base(dbContext)
        { }
    }
}
