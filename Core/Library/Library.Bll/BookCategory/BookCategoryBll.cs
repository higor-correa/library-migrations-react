using Library.Bll.BookCategory.Interfaces;
using Library.Bll.BookCategory.Types.Interface;
using Library.Domain.DTO.BookCategory;
using Library.Domain.Enums;
using Library.Repository.Interfaces;
using System.Collections.Generic;

namespace Library.Bll.BookCategory
{
    public class BookCategoryBll : IBookCategoryBll
    {
        private readonly IBookCategoryRepository _repository;
        private readonly IBookCategoryTypesBll _categoryTypesBll;

        public BookCategoryBll(IBookCategoryRepository repository,
                               IBookCategoryTypesBll categoryTypesBll)
        {
            _repository = repository;
            _categoryTypesBll = categoryTypesBll;
        }

        public BookCategoryResponseDTO Get(BookCategoryEnum bookCategory)
        {
            return _categoryTypesBll.Get(bookCategory);
        }

        public IList<BookCategoryResponseDTO> GetAll()
        {
            return _categoryTypesBll.GetAll();
        }
    }
}
