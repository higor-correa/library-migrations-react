using FluentAssertions;
using Library.Bll.Book.Validators.Interface;
using Library.Bll.Exceptions;
using Library.Bll.Test.Builder;
using Library.Domain.Entities;
using Library.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Library.Bll.Test.Integration.Book.Validators
{
    public class BookPublishValidatorTest : LibraryIntegrationTestBase
    {
        [Fact]
        public void Should_Validate_Null_References()
        {
            var bookPublishValidator = Resolve<IBookPublishValidator>();
            BookEntity book = null;
            PublishierEntity publishierEntity = null;
            var errors = new List<string>
            {
                "Book must be set to publish a book",
                "Publisher must be set to publish a book"
            };

            Action act = () => bookPublishValidator.ValidatePublish(book, publishierEntity);

            act.Should()
               .Throw<BusinessException>()
               .WithMessage(string.Join(Environment.NewLine, errors));
        }

        [Fact]
        public void Should_Validatebook_Already_Published()
        {
            var bookPublishValidator = Resolve<IBookPublishValidator>();
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

            book = bookRepository.Get(book.Id).FirstOrDefault();

            Action act = () => bookPublishValidator.ValidatePublish(book, publisher);
            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"Book ({book.Id}) is already published!");
        }

        [Fact]
        public void Should_Validate_Publish_Withoutpublisher()
        {
            var bookPublishValidator = Resolve<IBookPublishValidator>();
            var bookRepository = Resolve<IBookRepository>();

            var author = new AuthorBuilder()
                .Build();

            var book = new BookBuilder()
                .WithPublisher(null)
                .Build();

            var authorBook = new AuthorBookBuilder().WithAuthor(author).WithBook(book).Build();
            AddEntities(author, book, authorBook);

            book = bookRepository.Get(book.Id).FirstOrDefault();

            Action act = () => bookPublishValidator.ValidatePublish(book, null);
            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"Publisher must be set to publish a book");
        }

        [Fact]
        public void Should_Validate_Author_Without_Publisher()
        {
            var bookPublishValidator = Resolve<IBookPublishValidator>();
            var bookRepository = Resolve<IBookRepository>();
            var publisher = new PublisherBuilder().Build();

            var author = new AuthorBuilder()
                .Build();

            var book = new BookBuilder()
                .Build();

            var authorBook = new AuthorBookBuilder().WithAuthor(author).WithBook(book).Build();
            AddEntities(publisher, author, book, authorBook);

            book = bookRepository.Get(book.Id).FirstOrDefault();

            Action act = () => bookPublishValidator.ValidatePublish(book, publisher);
            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"The following authors do not have publishers on his register:{Environment.NewLine}{author.FirstName}" +
                            $"{Environment.NewLine}The publisher of publication's book must be from one of the authors!");
        }

        [Fact]
        public void Should_Validate_publisher_Different_From_Authors()
        {
            var bookPublishValidator = Resolve<IBookPublishValidator>();
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

            book = bookRepository.Get(book.Id).FirstOrDefault();

            Action act = () => bookPublishValidator.ValidatePublish(book, anotherPublisher);
            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"{Environment.NewLine}The publisher of publication's book must be from one of the authors!");
        }

        [Fact]
        public void Should_Validate_Publish_With_Excedent_Authors()
        {
            var bookPublishValidator = Resolve<IBookPublishValidator>();
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
            book = bookRepository.Get(book.Id).FirstOrDefault();

            Action act = () => bookPublishValidator.ValidatePublish(book, publisher);

            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"Book can't have more than 3 authors!");
        }
    }
}
