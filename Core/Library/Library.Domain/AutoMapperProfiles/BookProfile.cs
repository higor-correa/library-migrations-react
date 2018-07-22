using AutoMapper;
using Library.Domain.DTO.Author;
using Library.Domain.DTO.Book;
using Library.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.AutoMapperProfiles
{
    public class BookProfile : Profile
    {
        public void CreateMaps()
        {
            CreateMap<BookRequestDTO, BookEntity>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<BookEntity, BookResponseDTO>().ForMember(x => x.Authors,
                opt => opt.MapFrom(x => Mapper.Map<List<AuthorResponseDTO>>(x.AuthorsBook.Select(a => a.Author))));
        }
    }
}
