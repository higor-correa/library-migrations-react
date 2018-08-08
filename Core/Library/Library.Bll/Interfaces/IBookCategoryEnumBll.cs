using Library.Domain.DTO.BookCategory;
using Library.Domain.Enums;
using System.Collections.Generic;

namespace Library.Bll.Interfaces
{
    public interface IBookCategoryEnumBll
    {
        BookCategoryResponseDTO Get(BookCategoryEnum bookCategory);
        IList<BookCategoryResponseDTO> GetAll();
    }
}
