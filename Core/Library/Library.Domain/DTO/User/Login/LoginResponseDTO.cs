using Library.Domain.DTO.User.Login.Token;

namespace Library.Domain.DTO.User.Login
{
    public class LoginResponseDTO
    {
        public UserResponseDTO User { get; set; }
        public TokenResponseDTO Token { get; set; }
    }
}
