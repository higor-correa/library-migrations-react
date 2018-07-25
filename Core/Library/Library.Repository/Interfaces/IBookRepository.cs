using Library.Domain.Entities;

namespace Library.Repository.Interfaces
{
    public interface IBookRepository : ICrudRepository<BookEntity>
    {
    }
}
