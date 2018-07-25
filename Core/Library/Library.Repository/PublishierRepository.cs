using Library.Domain.Entities;
using Library.Repository.Context;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public class PublishierRepository : BaseCrudRepository<PublishierEntity>, IPublishierRepository
    {
        public PublishierRepository(LibraryContext dbContext) : base(dbContext)
        { }
    }
}
