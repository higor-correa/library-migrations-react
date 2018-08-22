using Library.Bll.Book.Validators.Interface;
using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Bll.Book.Validators.Strategies
{
    public class BookAlreadyPublishedStrategy : IBookValidationStrategy
    {
        public IList<string> Validate(BookEntity book, PublishierEntity publisher)
        {
            var erros = new List<string>();

            if (book.Publishier != null)
                erros.Add($"Book ({book.Id}) is already published!");

            return erros;
        }
    }
}
