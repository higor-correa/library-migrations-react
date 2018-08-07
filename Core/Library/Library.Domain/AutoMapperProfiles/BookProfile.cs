using AutoMapper;
using Library.Domain.DTO.Book;
using Library.Domain.DTO.BookCategory;
using Library.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.AutoMapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookRequestDTO, BookEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.BookCategories, opt =>
                    opt.MapFrom(m => m.Categories.Select(x => new BookCategoryEntity { Category = x })))
                .ForMember(x => x.AuthorsBook, opt =>
                      opt.MapFrom(m => m.Authors.Select(x => new AuthorBookEntity { AuthorId = x })));

            CreateMap<BookEntity, BookResponseDTO>()
                .ForMember(x => x.Authors, opt => opt.Ignore())
                .ForMember(x => x.Categories, opt =>
                    opt.MapFrom(m => Mapper.Map<List<BookCategoryResponseDTO>>(m.BookCategories)));
        }
    }
}
