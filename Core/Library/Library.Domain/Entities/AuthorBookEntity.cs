using System;

namespace Library.Domain.Entities
{
    public class AuthorBookEntity : BaseEntity
    {
        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }

        public BookEntity Book { get; set; }
        public AuthorEntity Author { get; set; }
    }
}