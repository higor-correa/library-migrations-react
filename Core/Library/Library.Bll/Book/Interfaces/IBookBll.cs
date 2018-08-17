using Library.Domain.DTO.Book;
using System;
using System.Collections.Generic;

namespace Library.Bll.Book.Interfaces
{
    public interface IBookBll
    {
        BookResponseDTO Get(Guid id);
        IList<BookResponseDTO> GetAll();
        Guid Insert(BookRequestDTO request);
        void Update(Guid id, BookRequestDTO request);
        void Delete(Guid id);
        void PublishBook(Guid? id, PublishBookRequestDTO publishBookRequest);
    }
}
