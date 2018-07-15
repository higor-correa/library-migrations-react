using Library.Domain.DTO.Author;
using Library.Domain.DTO.BookCategory;
using Library.Domain.DTO.Publishier;
using System;
using System.Collections.Generic;

namespace Library.Domain.DTO.Book
{
    public class BookResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid PublishierId { get; set; }

        public PublishierResponseDTO Publishier { get; set; }
        public IList<AuthorResponseDTO> Authors { get; set; }
        public IList<BookCategoryResponseDTO> Categories { get; set; }
    }
}
