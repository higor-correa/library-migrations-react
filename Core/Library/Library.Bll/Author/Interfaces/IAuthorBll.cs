using Library.Domain.DTO.Author;
using System;
using System.Collections.Generic;

namespace Library.Bll.Author.Interfaces
{
    public interface IAuthorBll
    {
        AuthorResponseDTO Get(Guid id);
        IList<AuthorResponseDTO> GetAll();
        Guid Insert(AuthorRequestDTO request);
        void Update(Guid id, AuthorRequestDTO request);
        void Delete(Guid id);
    }
}
