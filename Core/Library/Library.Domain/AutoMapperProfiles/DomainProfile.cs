using AutoMapper;
using Library.Domain.DTO.Author;
using Library.Domain.Entities;

namespace Library.Domain.AutoMapperProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {

            CreateMap<AuthorRequestDTO, AuthorEntity>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
