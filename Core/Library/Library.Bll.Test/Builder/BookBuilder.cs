using Library.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Library.Bll.Test.Builder
{
    public class BookBuilder
    {
        private string _name;
        private string _code;
        private Guid? _publisherId;
        private DateTime? _publishDate;
        private PublishierEntity _publisher;
        private IList<AuthorBookEntity> _authorsBook;
        private IList<BookCategoryEntity> _bookCategories;

        public BookBuilder()
        {
            var guid = Guid.NewGuid();
            var code = guid.ToString().Substring(0, 3);
            _code = $"BOK-{code}";
            _name = guid.ToString();
        }

        public BookEntity Build()
        {
            return new BookEntity
            {
                AuthorsBook = _authorsBook ?? new List<AuthorBookEntity>(),
                BookCategories = _bookCategories ?? new List<BookCategoryEntity>(),
                Code = _code,
                Id = Guid.NewGuid(),
                Name = _name,
                PublishDate = _publishDate,
                Publishier = _publisher,
                PublishierId = _publisherId
            };
        }

        public BookBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public BookBuilder WithCode(string code)
        {
            _code = code;
            return this;
        }

        public BookBuilder WithPublisherId(Guid? publisherId)
        {
            _publisherId = publisherId;

            if (!publisherId.HasValue)
                _publisher = null;

            return this;
        }

        public BookBuilder WithPublishDate(DateTime? publishDate)
        {
            _publishDate = publishDate;
            return this;
        }

        public BookBuilder WithPublisher(PublishierEntity publisher)
        {
            _publisher = publisher;
            _publisherId = publisher?.Id ?? _publisherId;
            return this;
        }

        public BookBuilder WithAuthorsBook(IList<AuthorBookEntity> authorsBook)
        {
            _authorsBook = authorsBook;
            return this;
        }

        public BookBuilder WithBookCategories(IList<BookCategoryEntity> bookCategories)
        {
            _bookCategories = bookCategories;
            return this;
        }
    }
}
