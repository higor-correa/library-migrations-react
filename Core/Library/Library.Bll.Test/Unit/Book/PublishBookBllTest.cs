using FluentAssertions;
using Library.Bll.Book;
using Library.Bll.Book.Validators.Interface;
using Library.Bll.Test.Builder;
using Library.Repository.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Library.Bll.Test.Unit.Book
{
    public class PublishBookBllTest
    {
        private IBookRepository _bookRepository;
        private IBookPublishValidator _publishBookValidator;
        private PublishBookBll _publishBookll;

        [SetUp]
        public void SetUp()
        {
            _publishBookValidator = Substitute.For<IBookPublishValidator>();
            _bookRepository = Substitute.For<IBookRepository>();
            _publishBookll = new PublishBookBll(_publishBookValidator, _bookRepository);
        }

        [TestCase]
        public void Should_Publish_Book()
        {
            var publisher = new PublisherBuilder().Build();
            var book = new BookBuilder().Build();

            _publishBookll.Publish(book, publisher);

            _publishBookValidator.Received(1).ValidatePublish(Arg.Is(book), Arg.Is(publisher));

            book.Publishier.Should().BeEquivalentTo(publisher);
        }
    }
}
