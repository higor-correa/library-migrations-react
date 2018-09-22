using Library.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Library.Bll.Test.Builder
{
    public class PublisherBuilder
    {
        private string _name;
        private string _code;
        private IList<BookEntity> _publishedBooks;
        private IList<AuthorEntity> _authors;

        public PublisherBuilder()
        {
            var guid = Guid.NewGuid();
            var code = guid.ToString().Substring(0, 3);
            _code = $"PUB-{code}";
            _name = guid.ToString();
        }

        public PublishierEntity Build()
        {
            return new PublishierEntity
            {
                Authors = _authors,
                Code = _code,
                Id = Guid.NewGuid(),
                Name = _name,
                PublishedBooks = _publishedBooks
            };
        }

        public PublisherBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public PublisherBuilder WithCode(string code)
        {
            _code = code;
            return this;
        }

        public PublisherBuilder WithPublishedBooks(IList<BookEntity> publishedBooks)
        {
            _publishedBooks = publishedBooks;
            return this;
        }

        public PublisherBuilder WithAuthors(IList<AuthorEntity> authors)
        {
            _authors = authors;
            return this;
        }
    }
}
