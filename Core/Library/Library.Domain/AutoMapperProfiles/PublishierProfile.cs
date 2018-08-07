using AutoMapper;
using Library.Domain.DTO.Author;
using Library.Domain.DTO.Book;
using Library.Domain.DTO.Publishier;
using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Domain.AutoMapperProfiles
{
    public class PublishierProfile : Profile
    {
        public PublishierProfile()
        {
            CreateMap<PublishierRequestDTO, PublishierEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<PublishierEntity, PublishierResponseDTO>()
                .ForMember(x => x.Books, opt => opt.Ignore())
                .ForMember(x => x.Authors, opt => opt.MapFrom(p => Mapper.Map<List<AuthorResponseDTO>>(p.Authors)))
                .ForMember(x => x.Books, opt => opt.MapFrom(p => Mapper.Map<List<BookResponseDTO>>(p.PublishedBooks)));
        }
    }
}
