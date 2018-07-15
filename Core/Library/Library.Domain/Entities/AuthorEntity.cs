using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class AuthorEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public IList<AuthorBookEntity> BooksAuthor { get; set; }
    }
}
