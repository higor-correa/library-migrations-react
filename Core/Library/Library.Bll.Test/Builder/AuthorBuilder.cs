using Library.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Library.Bll.Test.Builder
{
    public class AuthorBuilder
    {
        private string _firstName;
        private string _lastName;
        private string _code;
        private PublishierEntity _publishier;
        private IList<AuthorBookEntity> _booksAuthor;

        public AuthorBuilder()
        {
            var guid = Guid.NewGuid();
            _firstName = guid.ToString().Substring(0, 5);
            _lastName = guid.ToString().Substring(5, 4);
            var code = guid.ToString().Substring(0, 3);
            _code = $"AUT-{code}";
        }

        public AuthorEntity Build()
        {
            return new AuthorEntity
            {
                Id = Guid.NewGuid(),
                FirstName = _firstName,
                LastName = _lastName,
                Code = _code,
                PublishierId = _publishier?.Id,
                Publishier = _publishier,
                BooksAuthor = _booksAuthor,
            };
        }

        public AuthorBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public AuthorBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public AuthorBuilder WithCode(string code)
        {
            _code = code;
            return this;
        }

        public AuthorBuilder WithPublishier(PublishierEntity publishier)
        {
            _publishier = publishier;
            return this;
        }

        public AuthorBuilder WithBooksAuthor(IList<AuthorBookEntity> booksAuthor)
        {
            _booksAuthor = booksAuthor;
            return this;
        }
    }
}
