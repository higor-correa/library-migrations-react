using Library.Domain.Entities;
using Library.Repository.Context;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public class AuthorRepository : BaseCrudRepository<AuthorEntity>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext dbContext) : base(dbContext)
        { }
    }
}
