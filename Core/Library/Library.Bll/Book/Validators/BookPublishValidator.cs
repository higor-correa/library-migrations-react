using Library.Bll.Book.Validators.Interface;
using Library.Bll.Exceptions;
using Library.Domain.Entities;

namespace Library.Bll.Book.Validators
{
    public class BookPublishValidator : IBookPublishValidator
    {
        public void ValidatePublish(BookEntity book, PublishierEntity publisher)
        {
            if (book == null)
                throw new BusinessException("Book must be set to publish a book");

            if (publisher == null)
                throw new BusinessException("Publisher must be set to publish a book");

            if (book.Publishier != null)
                throw new BusinessException($"Book ({book.Id}) is already published!");
        }
    }
}
