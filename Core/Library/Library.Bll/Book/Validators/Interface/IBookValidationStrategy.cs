using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Bll.Book.Validators.Interface
{
    public interface IBookValidationStrategy
    {
        IList<string> Validate(BookEntity book, PublishierEntity publisher);
    }
}
