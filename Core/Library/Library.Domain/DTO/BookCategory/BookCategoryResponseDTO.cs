using Library.Domain.Enums;
using System;

namespace Library.Domain.DTO.BookCategory
{
    public class BookCategoryResponseDTO
    {
        public Guid? BookId { get; set; }
        public BookCategoryEnum Category { get; set; }
        public string CategoryDescription { get; set; }
    }
}
