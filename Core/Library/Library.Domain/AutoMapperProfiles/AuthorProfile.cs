using AutoMapper;
using Library.Domain.DTO.Author;
using Library.Domain.DTO.Book;
using Library.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.AutoMapperProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorRequestDTO, AuthorEntity>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<AuthorEntity, AuthorResponseDTO>().ForMember(x => x.Books,
                opt => opt.MapFrom(x => Mapper.Map<List<BookResponseDTO>>(x.BooksAuthor.Select(b => b.Book))));
        }
    }
}
