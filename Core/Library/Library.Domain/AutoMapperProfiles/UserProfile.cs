using AutoMapper;
using Library.Domain.DTO.User;
using Library.Domain.Entities;

namespace Library.Domain.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequestDTO, UserEntity>()
                .ForMember(x => x.Password, opt =>
                    opt.Condition(dto => !string.IsNullOrWhiteSpace(dto.Password)));

            CreateMap<UserEntity, UserResponseDTO>();

            CreateMap<UserResponseDTO, UserEntity>()
                .ForMember(x => x.Password, opt => opt.Ignore());
        }
    }
}
