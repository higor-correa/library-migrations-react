using AutoMapper;
using Library.Domain.DTO.Author;
using Library.Domain.Entities;

namespace Library.Domain.AutoMapperProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorRequestDTO, AuthorEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.PublishierId, opt => opt.ResolveUsing(y => y.PublisherId));
            CreateMap<AuthorEntity, AuthorResponseDTO>().ForMember(x => x.Books, opt => opt.Ignore());
        }
    }
}
