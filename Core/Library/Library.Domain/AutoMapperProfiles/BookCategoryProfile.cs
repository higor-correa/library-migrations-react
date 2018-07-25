using AutoMapper;
using Library.Domain.DTO.BookCategory;
using Library.Domain.Entities;

namespace Library.Domain.AutoMapperProfiles
{
    public class BookCategoryProfile : Profile
    {
        public BookCategoryProfile()
        {
            CreateMap<BookCategoryEntity, BookCategoryResponseDTO>()
                .ForMember(x => x.CategoryDescription,
                    opt => opt.MapFrom(x => x.Category.ToString()));
        }
    }
}
