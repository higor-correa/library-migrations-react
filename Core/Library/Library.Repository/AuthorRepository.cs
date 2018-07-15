using Library.Domain.Entities;
using Library.Repository.Context;

namespace Library.Repository
{
    public class AuthorRepository : BaseRepository<AuthorEntity>
    {
        public AuthorRepository(LibraryContext dbContext) : base(dbContext)
        { }
    }
}
