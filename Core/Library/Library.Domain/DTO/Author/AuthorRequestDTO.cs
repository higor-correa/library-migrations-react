using System;

namespace Library.Domain.DTO.Author
{
    public class AuthorRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public Guid? PublisherId { get; set; }
    }
}
