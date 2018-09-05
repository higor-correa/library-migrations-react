using AutoMapper;
using Library.Bll.Exceptions;
using Library.Bll.User.Interfaces;
using Library.Bll.User.Token.Interfaces;
using Library.Domain.DTO.User;
using Library.Domain.DTO.User.Login;
using Library.Repository.Interfaces;
using System.Linq;

namespace Library.Bll.User
{
    public class LoginBll : ILoginBll
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenManager _tokenManager;

        public LoginBll(IUserRepository userRepository, ITokenManager tokenManager)
        {
            _userRepository = userRepository;
            _tokenManager = tokenManager;
        }

        public LoginResponseDTO Authenticate(string login, string password)
        {
            var user = _userRepository.GetForLogin(login, password)
                .FirstOrDefault() ?? throw new UnauthorizedException("Invalid credentials!");

            var token = _tokenManager.Generate(user);

            return new LoginResponseDTO
            {
                User = Mapper.Map<UserResponseDTO>(user),
                Token = token
            };
        }
    }
}
