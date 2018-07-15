using Library.Domain.Entities;
using Library.Repository.Context;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public class AuthorBookRepository : BaseCrudRepository<AuthorBookEntity>, IAuthorBookRepository
    {
        public AuthorBookRepository(LibraryContext dbContext) : base(dbContext)
        { }
    }
}
