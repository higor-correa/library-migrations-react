using Library.Domain.Entities;
using System;

namespace Library.Bll.Test.Builder
{
    public class AuthorBookBuilder
    {
        private BookEntity _book;
        private AuthorEntity _author;

        public AuthorBookBuilder()
        {
            _book = new BookBuilder().Build();
            _author = new AuthorBuilder().Build();
        }

        public AuthorBookEntity Build()
        {
            return new AuthorBookEntity
            {
                Id = Guid.NewGuid(),
                AuthorId = _author.Id,
                BookId = _book.Id,
                Book = _book,
                Author = _author
            };
        }

        public AuthorBookBuilder WithBook(BookEntity book)
        {
            _book = book;
            return this;
        }

        public AuthorBookBuilder WithAuthor(AuthorEntity author)
        {
            _author = author;
            return this;
        }
    }
}
