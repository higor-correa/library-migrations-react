using AutoMapper;
using Library.Domain.DTO.Author;
using Library.Domain.Entities;

namespace Library.Domain.AutoMapperProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorRequestDTO, AuthorEntity>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<AuthorEntity, AuthorResponseDTO>().ForMember(x => x.Books, opt => opt.Ignore());
        }
    }
}
