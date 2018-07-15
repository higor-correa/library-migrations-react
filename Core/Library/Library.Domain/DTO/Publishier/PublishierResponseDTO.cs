using Library.Domain.DTO.Author;
using Library.Domain.DTO.Book;
using System;
using System.Collections.Generic;

namespace Library.Domain.DTO.Publishier
{
    public class PublishierResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IList<BookResponseDTO> Books { get; set; }
        public IList<AuthorResponseDTO> Authors { get; set; }
    }
}
