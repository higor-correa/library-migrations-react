using FluentAssertions;
using Library.Bll.Book.Interfaces;
using Library.Bll.Test.Builder;
using Library.Repository.Interfaces;
using System.Linq;
using Xunit;

namespace Library.Bll.Test.Integration.Book
{
    public class PublishBookBllTest : LibraryIntegrationTestBase
    {
        [Fact]
        public void Should_Publish_Book()
        {
            var publishBookll = Resolve<IPublishBookBll>();
            var bookRepository = Resolve<IBookRepository>();

            var publisher = new PublisherBuilder().Build();
            var author = new AuthorBuilder().WithPublisher(publisher).Build();
            var book = new BookBuilder().Build();
            var authorBook = new AuthorBookBuilder().WithAuthor(author).WithBook(book).Build();
            AddEntities(publisher, book, author, authorBook);

            publishBookll.Publish(book, publisher);
            Commit();

            book = bookRepository.Get(book.Id).FirstOrDefault();

            book.Publishier.Should().BeEquivalentTo(publisher);
            book.PublishDate.Should().NotBeNull();
        }
    }
}
