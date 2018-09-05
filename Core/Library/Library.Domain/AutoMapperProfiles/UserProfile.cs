using AutoMapper;
using Library.Domain.DTO.User;
using Library.Domain.Entities;

namespace Library.Domain.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserResponseDTO>();

            CreateMap<UserResponseDTO, UserEntity>()
                .ForMember(x => x.Password, opt => opt.Ignore());
        }
    }
}
