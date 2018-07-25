using Library.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Library.Domain.DTO.Book
{
    public class BookRequestDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public IList<Guid> Authors { get; set; }
        public IList<BookCategoryEnum> Categories { get; set; }
    }
}
