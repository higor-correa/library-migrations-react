using Library.Bll.Book.Validators.Interface;
using Library.Bll.Extensions;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Bll.Book.Validators.Strategies
{
    public class BookAuthorsValidationStrategy : IBookValidationStrategy
    {
        private readonly List<string> _erros;

        public BookAuthorsValidationStrategy()
        {
            _erros = new List<string>();
        }

        public IList<string> Validate(BookEntity book, PublishierEntity publisher)
        {
            if (book == null || publisher == null)
                return _erros;

            if (book.AuthorsBook.Count > 3)
                _erros.Add($"Book can't have more than 3 authors!");

            ValidateAuthorsWithPublisher(book);

            ValidatePublisherFromAnyAuthor(book, publisher);

            return _erros;
        }

        private void ValidateAuthorsWithPublisher(BookEntity book)
        {
            var authorsWithoutPublisher = book.AuthorsBook
                            .Where(x => x.Author.PublishierId.IsEmpty())
                            .Select(x => x.Author);

            if (authorsWithoutPublisher.Any())
            {
                var authorsNames = string.Join(", ", authorsWithoutPublisher.Select(x => x.FirstName));

                _erros.Add($"The following authors do not have publishers on his register:" +
                    $"{Environment.NewLine}" +
                    $"{authorsNames}");
            }
        }


        private void ValidatePublisherFromAnyAuthor(BookEntity book, PublishierEntity publisher)
        {
            var publisherFromAnyAuthor = book.AuthorsBook
                .Select(x => x.Author.PublishierId)
                .Contains(publisher.Id);

            if (!publisherFromAnyAuthor)
                _erros.Add($"The publisher of publication's book must be from one of the authors!");
        }
    }
}
