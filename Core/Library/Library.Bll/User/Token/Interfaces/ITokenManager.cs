using Library.Domain.DTO.User.Login.Token;
using Library.Domain.Entities;

namespace Library.Bll.User.Token.Interfaces
{
    public interface ITokenManager
    {
        TokenResponseDTO Generate(UserEntity user);
    }
}
