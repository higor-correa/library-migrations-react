using Library.Bll.Book.Interfaces;
using Library.Bll.Book.Validators.Interface;
using Library.Domain.Entities;
using Library.Repository.Interfaces;

namespace Library.Bll.Book
{
    public class PublishBookBll : IPublishBookBll
    {
        private IBookPublishValidator _bookPublishValidator;
        private IBookRepository _bookRepository;

        public PublishBookBll(IBookPublishValidator bookPublishValidator,
                              IBookRepository bookRepository)
        {
            _bookPublishValidator = bookPublishValidator;
            _bookRepository = bookRepository;
        }

        public void Publish(BookEntity book, PublishierEntity publisher)
        {
            _bookPublishValidator.ValidatePublish(book, publisher);

            book.Publish(publisher);

            _bookRepository.Update(book);
        }
    }
}
