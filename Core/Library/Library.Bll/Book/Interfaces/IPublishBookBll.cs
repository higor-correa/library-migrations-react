using Library.Domain.Entities;

namespace Library.Bll.Book.Interfaces
{
    public interface IPublishBookBll
    {
        void Publish(BookEntity book, PublishierEntity publisher);
    }
}
