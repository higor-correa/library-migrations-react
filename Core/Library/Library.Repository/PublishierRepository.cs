using Library.Domain.Entities;
using Library.Repository.Context;

namespace Library.Repository
{
    public class PublishierRepository : BaseRepository<PublishierEntity>
    {
        public PublishierRepository(LibraryContext dbContext) : base(dbContext)
        { }
    }
}
