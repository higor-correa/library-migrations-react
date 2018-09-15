using FluentAssertions;
using Library.Bll.Book.Validators;
using Library.Bll.Exceptions;
using Library.Bll.Test.Builder;
using Library.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Library.Bll.Test.Unit.Book.Validators
{
    public class BookPublishValidatorTest
    {
        private BookPublishValidator _bookPublishValidator;
        private BookEntity _book;
        private PublishierEntity _publisher;

        [SetUp]
        public void SetUp()
        {
            _bookPublishValidator = new BookPublishValidator();
            _book = null;
            _publisher = null;
        }

        [TestCase]
        public void Should_Validate_Null_References()
        {
            var errors = new List<string>
            {
                "Book must be set to publish a book",
                "Publisher must be set to publish a book"
            };

            Action act = () => _bookPublishValidator.ValidatePublish(_book, _publisher);

            act.Should()
               .Throw<BusinessException>()
               .WithMessage(string.Join(Environment.NewLine, errors));
        }

        [TestCase]
        public void Should_Validate_Book_Already_Published()
        {
            _publisher = new PublisherBuilder().Build();

            var author = new AuthorBuilder()
                .WithPublisher(_publisher)
                .Build();

            _book = new BookBuilder()
                .WithPublisher(_publisher)
                .Build();

            var authorBook = new AuthorBookBuilder().WithAuthor(author).WithBook(_book).Build();
            var authorsBook = new List<AuthorBookEntity> { authorBook };

            _book.AuthorsBook = authorsBook;

            Action act = () => _bookPublishValidator.ValidatePublish(_book, _publisher);
            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"Book ({_book.Id}) is already published!");
        }

        [TestCase]
        public void Should_Validate_Publish_Without_Publisher()
        {
            var author = new AuthorBuilder()
                .Build();

            _book = new BookBuilder()
                .WithPublisher(_publisher)
                .Build();

            var authorBook = new AuthorBookBuilder().WithAuthor(author).WithBook(_book).Build();
            var authorsBook = new List<AuthorBookEntity> { authorBook };

            _book.AuthorsBook = authorsBook;

            Action act = () => _bookPublishValidator.ValidatePublish(_book, _publisher);
            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"Publisher must be set to publish a book");
        }

        [TestCase]
        public void Should_Validate_Author_Without_Publisher()
        {
            _publisher = new PublisherBuilder().Build();

            var author = new AuthorBuilder()
                .Build();

            _book = new BookBuilder()
                .Build();

            var authorBook = new AuthorBookBuilder().WithAuthor(author).WithBook(_book).Build();
            var authorsBook = new List<AuthorBookEntity> { authorBook };

            _book.AuthorsBook = authorsBook;

            Action act = () => _bookPublishValidator.ValidatePublish(_book, _publisher);
            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"The following authors do not have publishers on his register:{Environment.NewLine}{author.FirstName}" +
                            $"{Environment.NewLine}The publisher of publication's book must be from one of the authors!");
        }

        [TestCase]
        public void Should_Validate_Publisher_Different_From_Authors()
        {
            _publisher = new PublisherBuilder().Build();
            var anotherPublisher = new PublisherBuilder().Build();

            var author = new AuthorBuilder()
                .WithPublisher(_publisher)
                .Build();

            _book = new BookBuilder()
                .Build();

            var authorBook = new AuthorBookBuilder().WithAuthor(author).WithBook(_book).Build();
            var authorsBook = new List<AuthorBookEntity> { authorBook };

            _book.AuthorsBook = authorsBook;

            Action act = () => _bookPublishValidator.ValidatePublish(_book, anotherPublisher);
            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"{Environment.NewLine}The publisher of publication's book must be from one of the authors!");
        }

        [TestCase]
        public void Should_Validate_Publish_With_Excedent_Authors()
        {
            _publisher = new PublisherBuilder().Build();

            var authorBuilder = new AuthorBuilder().WithPublisher(_publisher);
            var author = authorBuilder.Build();
            var author2 = authorBuilder.Build();
            var author3 = authorBuilder.Build();
            var author4 = authorBuilder.Build();

            _book = new BookBuilder().Build();

            var authorBookBuilder = new AuthorBookBuilder().WithBook(_book);
            var authorBook = authorBookBuilder.WithAuthor(author).Build();
            var authorBook2 = authorBookBuilder.WithAuthor(author2).Build();
            var authorBook3 = authorBookBuilder.WithAuthor(author3).Build();
            var authorBook4 = authorBookBuilder.WithAuthor(author4).Build();

            var authorsBook = new List<AuthorBookEntity> { authorBook, authorBook2, authorBook3, authorBook4 };

            _book.AuthorsBook = authorsBook;

            Action act = () => _bookPublishValidator.ValidatePublish(_book, _publisher);

            act.Should()
               .Throw<BusinessException>()
               .WithMessage($"Book can't have more than 3 authors!");
        }
    }
}
