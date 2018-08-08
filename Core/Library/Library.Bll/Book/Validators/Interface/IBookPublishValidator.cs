using Library.Domain.Entities;

namespace Library.Bll.Book.Validators.Interface
{
    public interface IBookPublishValidator
    {
        void ValidatePublish(BookEntity book, PublishierEntity publisher);
    }
}
