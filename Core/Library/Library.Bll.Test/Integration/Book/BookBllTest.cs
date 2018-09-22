using FluentAssertions;
using Library.Bll.Book.Interfaces;
using Library.Bll.Book.Validators.Interface;
using Library.Bll.Exceptions;
using Library.Bll.Test.Builder;
using Library.Domain.DTO.Book;
using Library.Domain.Entities;
using Library.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Library.Bll.Test.Integration.Book
{
    public class BookBllTest : LibraryIntegrationTestBase
    {
        [Fact]
        public void Should_Unpublish_Book()
        {
            var bookBll = Resolve<IBookBll>();
            var bookRepository = Resolve<IBookRepository>();

            var publisher = new PublisherBuilder().Build();
            var book = new BookBuilder().WithPublisher(publisher).WithPublishDate(DateTime.Now).Build();
            AddEntities(publisher, book);

            bookBll.UnPublish(book.Id);

            book = bookRepository.Get(book.Id).FirstOrDefault();

            book.Publishier.Should().BeNull();
            book.PublishDate.Should().BeNull();
        }

        [Fact]
        public void Should_Validate_Unpublish_Without_Book()
        {
            var bookBll = Resolve<IBookBll>();

            var bookId = Guid.NewGuid();
            Action act = () => bookBll.UnPublish(bookId);

            act.Should()
               .Throw<EntityNotFoundException>()
               .WithMessage(new EntityNotFoundException($"Book ({bookId})").Message);
        }

        [Fact]
        public void Should_Publish_Book()
        {
            var bookBll = Resolve<IBookBll>();
            var bookRepository = Resolve<IBookRepository>();

            var publisher = new PublisherBuilder().Build();
            var author = new AuthorBuilder().WithPublisher(publisher).Build();
            var book = new BookBuilder().Build();
            var authorBook = new AuthorBookBuilder().WithAuthor(author).WithBook(book).Build();
            AddEntities(publisher, book, author, authorBook);

            bookBll.PublishBook(book.Id, new PublishBookRequestDTO { PublishierId = publisher.Id });
            Commit();

            book = bookRepository.Get(book.Id).FirstOrDefault();

            book.Publishier.Should().BeEquivalentTo(publisher);
            book.PublishDate.Should().NotBeNull();
        }

        [Fact]
        public void Should_Validate_Publish_Book_Without_Publisher()
        {
            var bookBll = Resolve<IBookBll>();
            var bookRepository = Resolve<IBookRepository>();

            var book = new BookBuilder().Build();
            AddEntities(book);

            var publisherId = Guid.NewGuid();

            Action act = () => bookBll.PublishBook(book.Id, new PublishBookRequestDTO { PublishierId = publisherId });
            act.Should()
               .Throw<EntityNotFoundException>()
               .WithMessage(new EntityNotFoundException($"Publishier ({publisherId})").Message);
        }

        [Fact]
        public void Should_Validate_Publish_Book_Without_Book()
        {
            var bookBll = Resolve<IBookBll>();
            var bookRepository = Resolve<IBookRepository>();

            var bookId = Guid.NewGuid();

            var publisherId = Guid.NewGuid();

            Action act = () => bookBll.PublishBook(bookId, new PublishBookRequestDTO { PublishierId = publisherId });
            act.Should()
               .Throw<EntityNotFoundException>()
               .WithMessage(new EntityNotFoundException($"Book ({bookId})").Message);
        }

        [Fact]
        public void Should_Validatebook_Already_Published()
        {
            var bookBll = Resolve<IBookBll>();
            var bookRepository = Resolve<IBookRepository>();

            var publisher = new PublisherBuilder().Build();

            var author = new AuthorBuilder()
                .WithPublisher(publisher)
                .Build();

            var book = new BookBuilder()
                .WithPublisher(publisher)
                .Build();

            var authorBook = new AuthorBookBuilder()
                .WithAuthor(author)
                .WithBook(book)
                .Build();

            AddEntities(publisher, author, book, authorBook);

            Action act = () => bookBll.PublishBook(book.Id, new PublishBookRequestDTO { PublishierId = publisher.Id });
            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"Book ({book.Id}) is already published!");
        }

        [Fact]
        public void Should_Validate_Author_Without_Publisher()
        {
            var bookBll = Resolve<IBookBll>();
            var bookRepository = Resolve<IBookRepository>();
            var publisher = new PublisherBuilder().Build();

            var author = new AuthorBuilder()
                .Build();

            var book = new BookBuilder()
                .Build();

            var authorBook = new AuthorBookBuilder().WithAuthor(author).WithBook(book).Build();
            AddEntities(publisher, author, book, authorBook);

            Action act = () => bookBll.PublishBook(book.Id, new PublishBookRequestDTO { PublishierId = publisher.Id });
            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"The following authors do not have publishers on his register:{Environment.NewLine}{author.FirstName}" +
                            $"{Environment.NewLine}The publisher of publication's book must be from one of the authors!");
        }

        [Fact]
        public void Should_Validate_Publisher_Different_From_Authors()
        {
            var bookBll = Resolve<IBookBll>();
            var bookRepository = Resolve<IBookRepository>();

            var publisher = new PublisherBuilder().Build();
            var anotherPublisher = new PublisherBuilder().Build();

            var author = new AuthorBuilder()
                .WithPublisher(publisher)
                .Build();

            var book = new BookBuilder()
                .Build();

            var authorBook = new AuthorBookBuilder().WithAuthor(author).WithBook(book).Build();
            AddEntities(publisher, anotherPublisher, author, book, authorBook);

            Action act = () => bookBll.PublishBook(book.Id, new PublishBookRequestDTO { PublishierId = anotherPublisher.Id });
            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"{Environment.NewLine}The publisher of publication's book must be from one of the authors!");
        }

        [Fact]
        public void Should_Validate_Publish_With_Excedent_Authors()
        {
            var bookBll = Resolve<IBookBll>();
            var bookRepository = Resolve<IBookRepository>();

            var publisher = new PublisherBuilder().Build();

            var authorBuilder = new AuthorBuilder().WithPublisher(publisher);
            var author = authorBuilder.Build();
            var author2 = authorBuilder.Build();
            var author3 = authorBuilder.Build();
            var author4 = authorBuilder.Build();

            var book = new BookBuilder().Build();

            var authorBookBuilder = new AuthorBookBuilder().WithBook(book);
            var authorBook = authorBookBuilder.WithAuthor(author).Build();
            var authorBook2 = authorBookBuilder.WithAuthor(author2).Build();
            var authorBook3 = authorBookBuilder.WithAuthor(author3).Build();
            var authorBook4 = authorBookBuilder.WithAuthor(author4).Build();

            var authorsBook = new List<AuthorBookEntity> { authorBook, authorBook2, authorBook3, authorBook4 };

            AddEntities(publisher, author, author2, author3, author4, book, authorBook, authorBook2, authorBook3, authorBook4);

            Action act = () => bookBll.PublishBook(book.Id, new PublishBookRequestDTO { PublishierId = publisher.Id });

            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"Book can't have more than 3 authors!");
        }
    }
}
