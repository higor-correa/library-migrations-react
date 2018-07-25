using Library.Domain.DTO.Book;
using System;
using System.Collections.Generic;

namespace Library.Domain.DTO.Author
{
    public class AuthorResponseDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public IList<BookResponseDTO> Books { get; set; }
    }
}
