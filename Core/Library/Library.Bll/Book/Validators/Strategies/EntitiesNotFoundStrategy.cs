using Library.Bll.Book.Validators.Interface;
using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Bll.Book.Validators.Strategies
{
    public class EntitiesNotFoundStrategy : IBookValidationStrategy
    {
        public IList<string> Validate(BookEntity book, PublishierEntity publisher)
        {
            var erros = new List<string>();

            if (book == null)
                erros.Add("Book must be set to publish a book");

            if (publisher == null)
                erros.Add("Publisher must be set to publish a book");

            return erros;
        }
    }
}
