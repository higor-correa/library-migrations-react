using Library.Domain.DTO.BookCategory;
using Library.Domain.Enums;
using System.Collections.Generic;

namespace Library.Bll.BookCategory.Types.Interface
{
    public interface IBookCategoryTypesBll
    {
        BookCategoryResponseDTO Get(BookCategoryEnum bookCategory);
        IList<BookCategoryResponseDTO> GetAll();
    }
}
