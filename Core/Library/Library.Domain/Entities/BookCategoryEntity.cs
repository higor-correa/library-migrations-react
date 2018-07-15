using Library.Domain.Enums;
using System;

namespace Library.Domain.Entities
{
    public class BookCategoryEntity : BaseEntity
    {
        public Guid BookId { get; set; }
        public BookCategoryEnum Category { get; set; }

        public BookEntity Book { get; set; }
    }
}
