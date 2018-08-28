using Library.Domain.DTO.BookCategory;
using Library.Domain.Enums;
using System.Collections.Generic;

namespace Library.Bll.BookCategory.Interfaces
{
    public interface IBookCategoryBll
    {
        BookCategoryResponseDTO Get(BookCategoryEnum bookCategory);
        IList<BookCategoryResponseDTO> GetAll();
    }
}
