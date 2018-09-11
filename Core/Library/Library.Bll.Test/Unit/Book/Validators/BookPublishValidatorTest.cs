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
                .WithPublishier(_publisher)
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
    }
}
