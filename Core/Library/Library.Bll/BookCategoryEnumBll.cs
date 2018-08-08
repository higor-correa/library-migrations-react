using Library.Bll.Extensions;
using Library.Bll.Interfaces;
using Library.Domain.DTO.BookCategory;
using Library.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Library.Bll
{
    public class BookCategoryEnumBll : IBookCategoryEnumBll
    {
        public BookCategoryResponseDTO Get(BookCategoryEnum bookCategory)
        {
            return new BookCategoryResponseDTO
            {
                Category = bookCategory,
                CategoryDescription = bookCategory.GetEnumDescription()
            };
        }

        public IList<BookCategoryResponseDTO> GetAll()
        {
            var response = new List<BookCategoryResponseDTO>();
            var enumValues = Enum.GetValues(typeof(BookCategoryEnum));

            foreach (var value in enumValues)
            {
                var enumValue = (BookCategoryEnum)value;
                response.Add(new BookCategoryResponseDTO
                {
                    Category = enumValue,
                    CategoryDescription = enumValue.GetEnumDescription()
                });
            }

            return response;
        }
    }
}
